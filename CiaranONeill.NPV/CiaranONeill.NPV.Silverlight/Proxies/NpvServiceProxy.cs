using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CiaranONeill.NPV.Silverlight.NpvServiceReference;

namespace CiaranONeill.NPV.Silverlight.Proxies
{
    public interface INpvService
    {
        Task<string> DoWork();
        Task<double> CalculateNpv(IList<Cashflow> npvData, double rate, RolloverType rolloverType, bool useXnpvFormula);
        Task<ObservableCollection<double>> GetRandomData(bool loadKnownValues);
    }

    public class NpvServiceProxy : INpvService
    {
        public Task<string> DoWork()
        {
            var th = new TaskHelper<NpvServiceClient, string>(new NpvServiceClient());
            return th.GetTask<string>(null);
        }

        public Task<double> CalculateNpv(IList<Cashflow> npvData, double rate, RolloverType rolloverType, bool useXnpvFormula)
        {
            // Would be good to use a ServiceResolver<> here to get an INpvService. This allow service changes without having to Update Service Reference...
            var th = new TaskHelper<NpvServiceClient, double>(new NpvServiceClient());
            return th.GetTask<double>(new object[] { npvData, rate, rolloverType, useXnpvFormula });
        }


        public Task<ObservableCollection<double>> GetRandomData(bool loadKnownValues)
        {
            var th = new TaskHelper<NpvServiceClient, ObservableCollection<double>>(new NpvServiceClient());
            return th.GetTask<ObservableCollection<double>>(new object[] { loadKnownValues});

            //var tcs = new TaskCompletionSource<ObservableCollection<double>>();

            //var client = new NpvServiceClient();

            //client.GetRandomDataCompleted += (s, e) =>
            //{
            //    if (e.Error != null)
            //        tcs.TrySetException(e.Error);
            //    else if (e.Cancelled)
            //        tcs.TrySetCanceled();
            //    else
            //        tcs.TrySetResult(e.Result);
            //};

            //client.GetRandomDataAsync();

            //return tcs.Task;
        }
    }
}