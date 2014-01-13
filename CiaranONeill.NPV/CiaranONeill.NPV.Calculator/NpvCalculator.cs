using System;
using System.Collections.Generic;
using System.Linq;

namespace CiaranONeill.NPV.Calculator
{
    public class NpvCalculator
    {
        public double CalculatePresentValue(double cashflow, double rate, int period = 1, int rollsPerPeriod = 1)
        {
            Guard.IsInRange(rate, "rate", 0, 100);
            Guard.GreaterThan(period, "period", 0);
            Guard.GreaterThan(rollsPerPeriod, "rollsPerPeriod", 0);            

            var pv = cashflow / Math.Pow(1 + (rate / rollsPerPeriod), period);

            return pv;
        }
    }

    public class DateRollCalculator
    {
        public IEnumerable<DateTime> GetDates(TimePeriod period)
        {
            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var endDate = new DateTime(DateTime.Now.Year + 10, 1, 1);
            switch(period)
            {
                case TimePeriod.Annually:
                    //return Enumerable.Range(DateTime.Now.Year, 10).Select(x => new DateTime(x, 1, 1));
                    return GetDates(endDate, 12);
                case TimePeriod.Quarterly:
                    return GetDates(endDate, 3);
                case TimePeriod.Monthly:
                    return GetDates(endDate, 1);
                default:
                    return GetDates(endDate, 12);
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

    public enum TimePeriod
    {
        Annually,
        Quarterly,
        Monthly
    }
}