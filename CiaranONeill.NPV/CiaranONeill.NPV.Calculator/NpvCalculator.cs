using System;
using System.Linq;

namespace CiaranONeill.NPV.Calculator
{
    public class NpvCalculator
    {
        public double CalculatePresentValue(double cashflow, double rate)
        {
            var pv = cashflow / (1 + rate);

            return pv;
        }
    }
}
