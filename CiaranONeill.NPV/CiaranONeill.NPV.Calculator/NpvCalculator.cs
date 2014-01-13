using System;
using System.Collections.Generic;
using System.Linq;

namespace CiaranONeill.NPV.Calculator
{
    public class NpvCalculator
    {
        private Random rng = new Random();

        public double CalculatePresentValue(double cashflow, double rate, int periodNumber = 1, RolloverType rolloverType = RolloverType.Annual)
        {
            Guard.IsInRange(rate, "rate", 0, 100);
            Guard.GreaterThan(periodNumber, "periodNumber", 0);         

            var pv = cashflow / Math.Pow(1 + (rate / (int)rolloverType), periodNumber);

            return pv;
        }

        public IEnumerable<double> GetRandomData()
        {
            var result = new List<double>();

            for (int i = 0; i < 3; i++)
                result.Add(GetRandomDouble(true));

            for (int i = 0; i < 9; i++)
                result.Add(GetRandomDouble(false));

            return result;
        }

        private double GetRandomDouble(bool generateNegativeValue)
        {
            double maxValue = generateNegativeValue ? -5000 : 30000;
            double minValue = generateNegativeValue ? 0 : 500;

            return rng.NextDouble() * (maxValue - minValue) + minValue;
        }
    }

    public class DateRollCalculator
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
    
    public enum RolloverType
    {
        Annual = 1,
        Quarter = 4,
        Month = 12
    }
}