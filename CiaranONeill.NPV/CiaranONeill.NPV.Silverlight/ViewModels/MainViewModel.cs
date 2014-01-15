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
            Increment = 0.25;

            LoadSampleData();
        }

        public async void Button()
        {
            MessageBox.Show(await _npvService.DoWork());
            var customers = await _npvService.GetCustomers(new Customer());
            var c = customers.First();
            MessageBox.Show(customers.First().Name);
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
