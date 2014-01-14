using System;
using System.Collections.Generic;

namespace CiaranONeill.NPV.Calculator
{
    public interface IDateRollCalculator
    {
        IEnumerable<DateTime> GetDates(RolloverType period);
    }
    
    public class DateRollCalculator : IDateRollCalculator
    {
        public IEnumerable<DateTime> GetDates(RolloverType period)
        {
            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            switch(period)
            {
                case RolloverType.Annual:
                    //return Enumerable.Range(DateTime.Now.Year, 10).Select(x => new DateTime(x, 1, 1));
                    return GetDates(new DateTime(DateTime.Now.Year + 12, 1, 1), 12); // 12 years
                case RolloverType.Quarter:
                    return GetDates(new DateTime(DateTime.Now.Year + 3, 1, 1), 3); // 12 quarters
                case RolloverType.Month:
                    return GetDates(new DateTime(DateTime.Now.Year + 1, 1, 1), 1); // 12 months
                default:
                    return GetDates(new DateTime(DateTime.Now.Year + 12, 1, 1), 12);
            }
        }

        private IEnumerable<DateTime> GetDates(DateTime endDate, int increment)
        {
            var period = new DateTime(DateTime.Now.Year, 1, 1);
            var list = new List<DateTime>();
            while (period < endDate)
            {
                yield return period;
                period = period.AddMonths(increment);
            }
        }
    }
}