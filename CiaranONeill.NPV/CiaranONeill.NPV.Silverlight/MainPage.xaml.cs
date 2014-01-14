using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CiaranONeill.NPV.Silverlight.NpvDateServiceReference;
using CiaranONeill.NPV.Silverlight.NpvServiceReference;

namespace CiaranONeill.NPV.Silverlight
{
    public partial class MainPage : UserControl
    {
        private readonly INpvService _npvService;
        private readonly INpvDateService _dateService;

        public List<Data> Cashflows { get; set; }

        public MainPage() : this(Bootstrapper.Resolve<INpvService>(), Bootstrapper.Resolve<INpvDateService>())
        {

        }

        public MainPage(INpvService npvService, INpvDateService dateService)
        {
            InitializeComponent();

            _dateService = dateService;
            _npvService = npvService;
            Cashflows = new List<Data>();   
            LoadData();
        }

        private async void LoadData()
        {
            var dates = await _dateService.GetDates(RolloverType.Month);
            var data = await _npvService.GetRandomData();

            var dates2 = dates.ToArray();
            var data2 = data.ToArray();
            for (int i = 0; i < dates.Count(); i++)
            {
                Cashflows.Add(new Data { Period = dates2[i], Cashflow = data2[i] });
            }

            lstCashflow.ItemsSource = Cashflows;
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show(await _npvService.GetHello());
            var customers = await _npvService.GetCustomers(new Customer());
            MessageBox.Show(customers.First().Name);
        }
    }

    public class Data
    {
        public DateTime Period { get; set; }
        public double Cashflow { get; set; }
    }
}
