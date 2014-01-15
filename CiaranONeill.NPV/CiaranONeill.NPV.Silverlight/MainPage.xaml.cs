using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public List<NpvData> Cashflows { get; set; }

        public MainPage() : this(Bootstrapper.Resolve<INpvService>(), Bootstrapper.Resolve<INpvDateService>())
        {

        }

        public MainPage(INpvService npvService, INpvDateService dateService)
        {
            InitializeComponent();

            _dateService = dateService;
            _npvService = npvService;
            Cashflows = new List<NpvData>();   
            LoadData();
        }

        private async void LoadData()
        {
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
            MessageBox.Show(await _npvService.GetHello());
            var customers = await _npvService.GetCustomers(new Customer());
            MessageBox.Show(customers.First().Name);
        }
    }

    public class NpvData
    {
        public DateTime Period { get; set; }
        public double Cashflow { get; set; }
    }
}
