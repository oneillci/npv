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
    public class MainViewModel
    {
        private readonly INpvService _npvService;
        private readonly INpvDateService _dateService;

        public ObservableCollection<NpvData> Cashflows { get; set; }
        public double LowerRate { get; set; }
        public double UpperRate { get; set; }
        public double Increment { get; set; }
        public double SelectedRate { get; set; }
        public ObservableCollection<double> Rates { get; set; }

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

            LoadSampleData();

            Rates = new ObservableCollection<double>() { 1, 5, 9, 13 };
        }

        //public async void Button()
        //{
        //    MessageBox.Show(await _npvService.DoWork());
        //    var customers = await _npvService.GetCustomers(new Customer());
        //    var c = customers.First();
        //    MessageBox.Show(customers.First().Name);
        //}

        public async void CalculateNpv()
        {
            var results = Validate();
            if (results.Any())
            {
                var message = string.Join(Environment.NewLine, results.Select(x => x));
                MessageBox.Show(message);
            }
        }

        private IEnumerable<string> Validate()
        {
            if (LowerRate > UpperRate)
                yield return "Lower rate must be less than upper rate";
            if (Increment > UpperRate)
                yield return "Increment must be less than lower rate";
            if (SelectedRate <= 0)
                yield return "You must choose a Selected Rate";
            
        }

        public async void LoadSampleData()
        {
            var list = new List<NpvData>();
            var dates = await _dateService.GetDates(RolloverType.Month);
            var data = await _npvService.GetRandomData();

            for (int i = 0; i < dates.Count(); i++)
            {
                list.Add(new NpvData { Period = dates[i], Cashflow = data[i] });
            }

            Cashflows = list.ToObservableCollection();
        }
    }

    public class NpvData
    {
        public DateTime? Period { get; set; }
        public double Cashflow { get; set; }
    }
}
