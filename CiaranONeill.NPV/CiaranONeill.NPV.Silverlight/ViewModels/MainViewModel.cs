using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CiaranONeill.NPV.Silverlight.Extensions;
using CiaranONeill.NPV.Silverlight.NpvDateServiceReference;
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

        public ObservableCollection<NpvData> Cashflows { get; set; }
        public double LowerRate { get; set; }
        public double UpperRate { get; set; }
        public double Increment { get; set; }
        public Rate SelectedRate { get; set; }
        public ObservableCollection<Rate> Rates { get; set; }
        public double NetPresentValue { get; set; }
        public Roll SelectedRoll { get; set; }
        public ObservableCollection<Roll> Rolls { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="npvService"></param>
        /// <param name="dateService"></param>
        public MainViewModel(INpvService npvService, INpvDateService dateService)
        {
            _dateService = dateService;
            _npvService = npvService;

            LowerRate = 1;
            UpperRate = 15;
            Increment = 4.0;
            Rolls = new ObservableCollection<Roll>()
            {
                new Roll { Value = "Annual" },
                new Roll { Value = "Quarter" },
                new Roll { Value = "Month" },
            };
            SelectedRoll = Rolls[0];

            LoadSampleData();

            Rates = new ObservableCollection<Rate>();
            IncrementChanged(4);
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
            NetPresentValue = await _npvService.CalculateNpv(Cashflows, SelectedRate.Value, roll, false);
        }

        /// <summary>
        /// Perform some rudimentary validation
        /// </summary>
        private IEnumerable<string> Validate()
        {
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
        public async void SelectedRolloverChanged()
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
            var list = new List<NpvData>();
            var roll = (NpvDateServiceReference.RolloverType)Enum.Parse(typeof(NpvServiceReference.RolloverType), SelectedRoll.Value, true);
            var dates = await _dateService.GetDates(roll);
            var data = await _npvService.GetRandomData();

            for (int i = 0; i < dates.Count(); i++)
            {
                list.Add(new NpvData { Period = dates[i], Cashflow = data[i] });
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
