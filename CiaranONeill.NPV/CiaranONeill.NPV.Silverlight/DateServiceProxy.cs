using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CiaranONeill.NPV.Silverlight.NpvDateServiceReference;

namespace CiaranONeill.NPV.Silverlight
{
    public class DateServiceProxy : INpvDateService
    {
        public Task<ObservableCollection<DateTime>> GetDates(RolloverType period)
        {
            var th = new TaskHelper<NpvDateServiceClient, ObservableCollection<DateTime>>(new NpvDateServiceClient());
            return th.GetTask<ObservableCollection<DateTime>>(new object[]{period});
        }
    }

    public interface INpvDateService
    {
        Task<ObservableCollection<DateTime>> GetDates(RolloverType period);
    }
}
