using System;
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
}