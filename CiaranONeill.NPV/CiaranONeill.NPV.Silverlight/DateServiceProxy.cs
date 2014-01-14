using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CiaranONeill.NPV.Silverlight.NpvDateServiceReference;

namespace CiaranONeill.NPV.Silverlight
{
    public class DateServiceProxy : INpvDateService
    {
        public Task<IEnumerable<DateTime>> GetDates(RolloverType period)
        {
            var tcs = new TaskCompletionSource<IEnumerable<DateTime>>();

            var client = new NpvDateServiceClient();

            client.GetDatesCompleted += (s, e) =>
            {
                if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else if (e.Cancelled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(e.Result);
            };

            client.GetDatesAsync(period);

            return tcs.Task;
        }
    }

    public interface INpvDateService
    {
        Task<IEnumerable<DateTime>> GetDates(RolloverType period);
    }
}
