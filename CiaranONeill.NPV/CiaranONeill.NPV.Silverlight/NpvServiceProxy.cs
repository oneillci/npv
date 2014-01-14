using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CiaranONeill.NPV.Silverlight.NpvServiceReference;

namespace CiaranONeill.NPV.Silverlight
{
    public class NpvServiceProxy : INpvService
    {
        public Task<string> GetHello()
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

        public Task<ObservableCollection<Customer>> GetCustomers(Customer customer)
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

        public Task<IEnumerable<double>> GetRandomData()
        {
            var tcs = new TaskCompletionSource<IEnumerable<double>>();

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

    public interface INpvService
    {
        Task<string> GetHello();
        Task<ObservableCollection<Customer>> GetCustomers(Customer customer);
        Task<IEnumerable<double>> GetRandomData();
    }
}