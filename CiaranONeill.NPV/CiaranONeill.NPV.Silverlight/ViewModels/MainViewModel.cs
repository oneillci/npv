using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Windows;
using CiaranONeill.NPV.Silverlight.Extensions;
using CiaranONeill.NPV.Silverlight.NpvServiceReference;
using CiaranONeill.NPV.Silverlight.Proxies;
using PropertyChanged;

namespace CiaranONeill.NPV.Silverlight.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel : Caliburn.Micro.PropertyChangedBase
    {
        private readonly INpvService _npvService;
        private readonly INpvDateService _dateService;

        public ObservableCollection<Cashflow> Cashflows { get; set; }
        public double InitialInvestment { get; set; }
        public double LowerRate { get; set; }
        public double UpperRate { get; set; }
        public double Increment { get; set; }
        public Rate SelectedRate { get; set; }
        public ObservableCollection<Rate> Rates { get; set; }
        public double NetPresentValue { get; set; }
        public Roll SelectedRoll { get; set; }
        public ObservableCollection<Roll> Rolls { get; set; }
        public bool IsNpv
        {
            get
            {
                return SelectedRoll.Value.ToLower() == "annual";
            }
        }
        public ObservableCollection<Npv> NpvList { get; set; }
        public bool PreserveValues { get; set; }
        public bool LoadKnownValues { get; set; }
        public bool HasNpvValues { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="npvService"></param>
        /// <param name="dateService"></param>
        public MainViewModel(INpvService npvService, INpvDateService dateService)
        {
            _dateService = dateService;
            _npvService = npvService;

            Cashflows = new ObservableCollection<Cashflow>();
            NpvList = new ObservableCollection<Npv>();
            InitialInvestment = 1000;
            LowerRate = 1;
            UpperRate = 15;
            Increment = 1.0;
            Rolls = new ObservableCollection<Roll>()
            {
                new Roll { Value = "Annual" },
                new Roll { Value = "Quarter" },
                new Roll { Value = "Month" },
            };
            SelectedRoll = Rolls[0];
            LoadKnownValues = true;
            PreserveValues = true;
            NpvList = new ObservableCollection<Npv>();
            LoadSampleData();

            Rates = new ObservableCollection<Rate>();
            IncrementChanged(Increment);
        }

        /// <summary>
        /// Calculate the NPV based on the currently entered values
        /// </summary>
        public async void CalculateNpv()
        {
            var results = Validate();
            if (results.Any())
            {
                var message = string.Join(Environment.NewLine, results.Select(x => x));
                MessageBox.Show(message);
                return;
            }
            var roll = (NpvServiceReference.RolloverType)Enum.Parse(typeof(NpvServiceReference.RolloverType), SelectedRoll.Value, true);

            var npvRequest = new NpvRequest
            {
                Cashflows = this.Cashflows, 
                Increment = this.Increment, 
                InitialInvestment = this.InitialInvestment, 
                LowerRate = this.LowerRate, 
                UpperRate = this.UpperRate,
                RollType = roll
            };
                
            var values = await _npvService.CalculateNpvForNpvRequest(npvRequest, false);            
            NetPresentValue = values.NetPresentValues.First(x => x.Rate == SelectedRate.Value).Value;

            NpvList.Clear();
            HasNpvValues = true;

            values.NetPresentValues.ToObservable()
                .Zip(Observable.Interval(TimeSpan.FromMilliseconds(15)), (npvData, time) => npvData)
                .ObserveOnDispatcher()
                .Subscribe(x => NpvList.Add(new Npv { Rate = x.Rate, Value = x.Value }));
        }

        /// <summary>
        /// Perform some rudimentary validation
        /// </summary>
        private IEnumerable<string> Validate()
        {
            if (UpperRate > 100)
                yield return "Upper rate must be less than 100";
            if (LowerRate > UpperRate)
                yield return "Lower rate must be less than upper rate";
            if (Increment > UpperRate)
                yield return "Increment must be less than lower rate";
            if (SelectedRate == null)
                yield return "You must choose a Selected Rate";
            
        }

        /// <summary>
        /// When the selected roll changes, update the sample data
        /// </summary>
        public void SelectedRolloverChanged()
        {
            LoadSampleData();
        }

        /// <summary>
        /// When the Increment has changed, reinitialise the Rates combo box
        /// </summary>
        /// <param name="newIncrement"></param>
        public void IncrementChanged(double newIncrement)
        {
            if (newIncrement <= 0) return;
            if (newIncrement > UpperRate)
                MessageBox.Show("Increment must be less than lower rate");

            Rates.Clear();
            double currentIncrement = LowerRate;
            while (currentIncrement <= UpperRate)
            {
                Rates.Add(new Rate { Value = currentIncrement });
                currentIncrement += newIncrement;
            }
            SelectedRate = Rates[0];
        }

        /// <summary>
        /// Load some sample data for the selected roll and update the Cashflows list
        /// </summary>
        public async void LoadSampleData()
        {
            var list = new List<Cashflow>();
            var roll = (NpvDateServiceReference.RolloverType)Enum.Parse(typeof(NpvServiceReference.RolloverType), SelectedRoll.Value, true);
            var dates = await _dateService.GetDates(roll);
            var data = new ObservableCollection<double>();
            
            data = PreserveValues && Cashflows.Count > 0 
                ? Cashflows.Select(x => x.Amount).ToObservableCollection() 
                : await _npvService.GetRandomData(LoadKnownValues);

            for (int i = 0; i < dates.Count(); i++)
            {
                list.Add(new Cashflow { Period = dates[i], Amount = data[i] });
            }

            Cashflows = list.ToObservableCollection();
            NetPresentValue = 0;            
        }
    }

    public class Roll
    {
        public string Value { get; set; }
    }

    public class Rate
    {
        public double Value { get; set; }
    }
    
}
