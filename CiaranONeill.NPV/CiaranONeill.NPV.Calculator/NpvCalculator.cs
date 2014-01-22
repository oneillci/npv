using System;
using System.Collections.Generic;
using System.Linq;

namespace CiaranONeill.NPV.Calculator
{
    public interface INpvCalculator
    {
        double CalculateNpv(double initialInvestment, IList<Cashflow> npvData, double rate, RolloverType rolloverType, bool useXnpvFormula);
        double CalculatePresentValue(double cashflow, double rate, double exponent , RolloverType rolloverType = RolloverType.Annual);
        NpvResponse CalculateNpvForNpvRequest(NpvRequest request, bool useXnpvFormula);
        IEnumerable<double> GetRandomData(bool loadKnownValues);
    }


    public class NpvCalculator : INpvCalculator
    {
        private Random rng = new Random();

        /// <summary>
        /// Calculates the NPV for a series of cashflows
        /// </summary>
        /// <param name="npvData"></param>
        /// <param name="rate"></param>
        /// <param name="rolloverType"></param>
        /// <param name="useXnpvFormula">When true the return value is calculated based on the Excel XNPV formula, when false simply uses the standard NPV formula</param>
        /// <returns></returns>
        public double CalculateNpv(double initialInvestment, IList<Cashflow> npvData, double rate, RolloverType rolloverType, bool useXnpvFormula)
        {
            Guard.IsInRange(rate, "rate", 0, 100);

            double npv = 0;
            if (useXnpvFormula)
            {
                var firstDate = npvData.First().Period;
                for (int i = 0; i < npvData.Count(); i++)
                {
                    double exponent;
                    exponent = i == 0 ? 0 : GetNpvExponent(firstDate, npvData[i].Period);
                    npv += CalculatePresentValue(npvData[i].Amount, rate / 100, exponent, rolloverType);
                }
            }
            else
            {
                // Change the rate if it's monthly or quarterly. http://www.vertex42.com/ExcelArticles/discount-factors.html
                switch (rolloverType)
                {
                    case RolloverType.Month:
                        rate = rate / 12;
                        break;
                    case RolloverType.Quarter:
                        rate = rate / 4;
                        break;
                    default:
                        break;
                }

                for (int i = 0; i < npvData.Count(); i++)
                {
                    npv += CalculatePresentValue(npvData[i].Amount, rate / 100, i + 1, rolloverType);
                }                
            }
            // Subtract initial investment. Example 2: http://office.microsoft.com/en-au/excel-help/npv-HP005209199.aspx
            return npv - initialInvestment;
        }

        /// <summary>
        /// Calculates the NPV for a series of cashflows
        /// </summary>
        /// <param name="request"></param>
        /// <param name="useXnpvFormula"></param>
        /// <returns></returns>
        public NpvResponse CalculateNpvForNpvRequest(NpvRequest request, bool useXnpvFormula)
        {
            var response = new NpvResponse();

            for (double rate = request.LowerRate; rate <= request.UpperRate; rate+= request.Increment)
            {
                var npv = CalculateNpv(request.InitialInvestment, request.Cashflows, rate, request.RollType, useXnpvFormula);
                response.NetPresentValues.Add(new Npv{ Rate = rate, Value = npv});
            }

            return response;
        }
  
        /// <summary>
        /// Calculate the Present value of a cashflow
        /// </summary>
        public double CalculatePresentValue(double cashflow, double rate, double exponent, RolloverType rolloverType = RolloverType.Annual)
        {
            Guard.IsInRange(rate, "rate", 0, 100);
            Guard.GreaterThan(exponent, "power", -1);         

            var pv = cashflow / Math.Pow(1 + rate, exponent);

            return pv;
        }

        /// <summary>
        /// Returns some random doubles that can be used in the UI
        /// </summary>
        /// <returns></returns>
        public IEnumerable<double> GetRandomData(bool loadKnownValues)
        {
            if (loadKnownValues)
                return new double[]
                {
                    25,
                    25,
                    30,
                    35,
                    20,
                    15,
                    25,
                    25,
                    15,
                    15,
                    20,
                    10,
                    10,
                    5,
                    5,
                    5,
                };
           

            var result = new List<double>();

            for (int i = 0; i < 3; i++)
                result.Add(GetRandomDouble(true));

            for (int i = 0; i < 9; i++)
                result.Add(GetRandomDouble(false));

            return result;
        }

        /// <summary>
        /// Gets a random double (optionally negative)
        /// </summary>
        private double GetRandomDouble(bool generateNegativeValue)
        {
            double maxValue = generateNegativeValue ? -5000 : 30000;
            double minValue = generateNegativeValue ? 0 : 500;

            return rng.NextDouble() * (maxValue - minValue) + minValue;
        }

        /// <summary>
        /// Returns the exponent for an NPV calculation
        /// </summary>
        private double GetNpvExponent(DateTime firstDate, DateTime period)
        {
            double days = (period - firstDate).Days;
            //double exponent = days / period.DaysInYear(); // Excel doesn't seem to take leap years into account? I won't either...
            double exponent = days / 365;

            return exponent;
        }
    }

    public enum RolloverType
    {
        Annual = 1,
        Quarter = 4,
        Month = 12
    }
}