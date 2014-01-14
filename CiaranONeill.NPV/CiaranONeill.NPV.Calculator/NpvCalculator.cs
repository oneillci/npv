using System;
using System.Collections.Generic;
using System.Linq;

namespace CiaranONeill.NPV.Calculator
{
    public interface INpvCalculator
    {
        double CalculatePresentValue(double cashflow, double rate, int periodNumber = 1, RolloverType rolloverType = RolloverType.Annual);
        IEnumerable<double> GetRandomData();
    }

    public class NpvCalculator : INpvCalculator
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

    
    public enum RolloverType
    {
        Annual = 1,
        Quarter = 4,
        Month = 12
    }
}