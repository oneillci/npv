using System;
using System.Linq;

namespace CiaranONeill.NPV.Calculator
{
    public class NpvCalculator
    {
        
        public double CalculatePresentValue(double cashflow, double rate, int period = 1, int rollsPerPeriod = 1)
        {
            if (rate <= 0)
                throw new ArgumentException("Rate cannot be <= 0");
            if (rate > 100)
                throw new ArgumentException("Rate cannot be > 100");

            var pv = cashflow / Math.Pow(1 + rate, period);

            return pv;
        }
    }
}
