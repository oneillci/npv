using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CiaranONeill.NPV.Calculator;
using CiaranONeill.NPV.Silverlight.NpvServiceReference;

namespace CiaranONeill.NPV.Silverlight
{
    public partial class MainPage : UserControl
    {
        private INpvService _npvService;

        public List<Data> Cashflows { get; set; }

        public MainPage() : this(Bootstrapper.Resolve<INpvService>())
        {

        }

        public MainPage(INpvService npvService)
        {
            _npvService = npvService;

            InitializeComponent();

            Cashflows = new List<Data>();

            var dates = new DateRollCalculator().GetDates(RolloverType.Month).ToList();
            var data = new NpvCalculator().GetRandomData().ToList();

            for (int i = 0; i < dates.Count(); i++)
            {
                Cashflows.Add(new Data { Period = dates[i], Cashflow = data[i] });
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
