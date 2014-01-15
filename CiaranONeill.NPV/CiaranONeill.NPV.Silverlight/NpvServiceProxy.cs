using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CiaranONeill.NPV.Silverlight.NpvServiceReference;

namespace CiaranONeill.NPV.Silverlight
{
    public interface INpvService
    {
        Task<string> DoWork();
        Task<ObservableCollection<Customer>> GetCustomers(Customer customer);
        Task<ObservableCollection<double>> GetRandomData();
    }

    public class NpvServiceProxy : INpvService
    {
        public Task<string> DoWork()
        {
            var th = new TaskHelper<NpvServiceClient, string>(new NpvServiceClient());
            return th.GetTask<string>(null);
        }

        public Task<ObservableCollection<Customer>> GetCustomers(Customer customer)
        {
            var th = new TaskHelper<NpvServiceClient, ObservableCollection<Customer>>(new NpvServiceClient());
            return th.GetTask<ObservableCollection<Customer>>(new object[] { customer });
        }


        public Task<ObservableCollection<double>> GetRandomData()
        {
            var th = new TaskHelper<NpvServiceClient, ObservableCollection<double>>(new NpvServiceClient());
            return th.GetTask<ObservableCollection<double>>(null);

            var tcs = new TaskCompletionSource<ObservableCollection<double>>();

            var client = new NpvServiceClient();

            client.GetRandomDataCompleted += (s, e) =>
            {
                if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else if (e.Cancelled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(e.Result);
            };

            client.GetRandomDataAsync();

            return tcs.Task;
        }
    }

}