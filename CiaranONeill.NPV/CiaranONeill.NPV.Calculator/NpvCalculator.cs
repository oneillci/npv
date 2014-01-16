using System;
using System.Collections.Generic;
using System.Linq;

namespace CiaranONeill.NPV.Calculator
{
    public interface INpvCalculator
    {
        double CalculateNpv(IList<NpvData> npvData, double rate, RolloverType rolloverType, bool useXnpvFormula);
        double CalculatePresentValue(double cashflow, double rate, int power = 1, RolloverType rolloverType = RolloverType.Annual);
        IEnumerable<double> GetRandomData();
    }

    public class NpvCalculator : INpvCalculator
    {
        private Random rng = new Random();

        public double CalculateNpv(IList<NpvData> npvData, double rate, RolloverType rolloverType, bool useXnpvFormula)
        {
            Guard.IsInRange(rate, "rate", 0, 100);

            double npv = 0;
            for (int i = 0; i < npvData.Count(); i++)
            {
                double power = GetPower(npvData[i].Period, i + 1, rolloverType);

                npv += CalculatePresentValue(npvData[i].Cashflow, rate/100, 1, rolloverType);
            }
            return npv;
        }

        public double GetPower(DateTime period, double iteration, RolloverType rolloverType)
        {

            switch(rolloverType)
            {
                case RolloverType.Annual:
                    return iteration;

                case RolloverType.Quarter:
                    // Get our base iteration
                    while (iteration > (int)rolloverType)
                        iteration -= (int)rolloverType;

                    if (iteration == 1)
                        return 1;
                    return ((iteration / (int)rolloverType) - (0.25)) + 1 + (iteration / (int)rolloverType);
                    //return iteration + 1 / 4;

                case RolloverType.Month:
                    if (iteration > 1)
                        return 1 + 1 / 12;
                    return 1;

                default:
                    return iteration;
            }
        }

        public double CalculatePresentValue(double cashflow, double rate, int power = 1, RolloverType rolloverType = RolloverType.Annual)
        {
            Guard.IsInRange(rate, "rate", 0, 100);
            Guard.GreaterThan(power, "power", 0);         

            //var pv = cashflow / Math.Pow(1 + (rate / (int)rolloverType), periodNumber);
            var pv = cashflow / Math.Pow(1 + rate, power);

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

    public class NpvData
    {
        public DateTime Period { get; set; }
        public double Cashflow { get; set; }
    }

    public enum RolloverType
    {
        Annual = 1,
        Quarter = 4,
        Month = 12
    }
}