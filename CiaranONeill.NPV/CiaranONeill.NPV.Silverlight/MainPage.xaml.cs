using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using CiaranONeill.NPV.Silverlight.NpvDateServiceReference;
using CiaranONeill.NPV.Silverlight.NpvServiceReference;
using CiaranONeill.NPV.Silverlight.Proxies;

namespace CiaranONeill.NPV.Silverlight
{
    public partial class MainPage : UserControl
    {
        private readonly INpvService _npvService;
        private readonly INpvDateService _dateService;

        public List<NpvData> Cashflows { get; set; }

        public MainPage() : this(Bootstrapper.Resolve<INpvService>(), Bootstrapper.Resolve<INpvDateService>())
        {

        }

        public MainPage(INpvService npvService, INpvDateService dateService)
        {
            InitializeComponent();

            _dateService = dateService;
            _npvService = npvService;
            LoadData();
        }

        private async void LoadData()
        {
            Cashflows = new List<NpvData>();   
            var dates = await _dateService.GetDates(RolloverType.Month);
            var data = await _npvService.GetRandomData();

            for (int i = 0; i < dates.Count(); i++)
            {
                Cashflows.Add(new NpvData { Period = dates[i], Cashflow = data[i] });
            }

            lstCashflow.ItemsSource = Cashflows;
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        { 
            MessageBox.Show(await _npvService.DoWork());
            var customers = await _npvService.GetCustomers(new Customer());
            var c = customers.First();
            ((dynamic)c).Age = 32;
            MessageBox.Show(customers.First().Name);
        }

        private void LoadSampleData_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	LoadData();
        }
    }

    public class NpvData
    {
        public DateTime? Period { get; set; }
        public double Cashflow { get; set; }
    }
}
