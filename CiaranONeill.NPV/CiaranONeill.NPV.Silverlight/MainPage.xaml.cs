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
        public List<Data> Cashflows { get; set; }

        public MainPage()
        {
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
            MessageBox.Show(await NpvServiceProxy.GetHello());
            var customers = await NpvServiceProxy.GetCustomers(new Customer());
            MessageBox.Show(customers.First().Name);
        }
    }

    public class NpvServiceProxy
    {
        public static Task<string> GetHello()
        {
            var tcs = new TaskCompletionSource<string>();

            var client = new NpvServiceClient();

            client.DoWorkCompleted += (s, e) =>
            {
                if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else if (e.Cancelled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(e.Result);
            };

            client.DoWorkAsync();

            return tcs.Task;
        }

        public static Task<ObservableCollection<Customer>> GetCustomers(Customer customer)
        {
            var tcs = new TaskCompletionSource<ObservableCollection<Customer>>();

            var client = new NpvServiceClient();

            client.GetCustomersCompleted += (s, e) =>
            {
                if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else if (e.Cancelled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(e.Result);
            };

            client.GetCustomersAsync(customer);

            return tcs.Task;
        }
    }

    public class Data
    {
        public DateTime Period { get; set; }
        public double Cashflow { get; set; }
    }
}
