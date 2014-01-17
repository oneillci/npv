using System;
using System.Collections.Generic;
using System.Linq;
using CiaranONeill.NPV.Calculator;
using Xunit;

namespace CiaranONeill.NPV.Tests
{
    public class NpvCalculatorTests
    {
        [Fact]
        public void CalculatePresentValue_ForFirstYear_ReturnsValue()
        {
            var sut = new NpvCalculator();
            var pv = sut.CalculatePresentValue(25, 0.10d, 1);

            Assert.Equal(22.72727, pv, 4);            
        }

        [Fact]
        public void CalculatePresentValue_ForFirstSecondYear_ReturnsValue()
        {
            var sut = new NpvCalculator();
            var pv = sut.CalculatePresentValue(25, 0.10d, 2);

            Assert.Equal(20.66115, pv, 4);
        }

        [Fact]
        public void CalculatePresentValue_ForFirstThirdYear_ReturnsValue()
        {
            var sut = new NpvCalculator();
            var pv = sut.CalculatePresentValue(30, 0.10d, 3);

            Assert.Equal(22.53944, pv, 4);
        }

        [Fact] 
        public void CalculateNpv_ForKnownAnnualValues_ReturnsExpected()
        {
            var sut = new NpvCalculator();
            var inputs = new List<NpvData>()
            {
                new NpvData() { Period = new DateTime(2014, 1, 1), Cashflow = 25 },
                new NpvData() { Period = new DateTime(2015, 1, 1), Cashflow = 25 },
                new NpvData() { Period = new DateTime(2016, 1, 1), Cashflow = 30 },
                new NpvData() { Period = new DateTime(2017, 1, 1), Cashflow = 35 },
                new NpvData() { Period = new DateTime(2018, 1, 1), Cashflow = 20 },
                new NpvData() { Period = new DateTime(2019, 1, 1), Cashflow = 15 },
                new NpvData() { Period = new DateTime(2020, 1, 1), Cashflow = 25 },
                new NpvData() { Period = new DateTime(2021, 1, 1), Cashflow = 25 },
                new NpvData() { Period = new DateTime(2022, 1, 1), Cashflow = 15 },
                new NpvData() { Period = new DateTime(2023, 1, 1), Cashflow = 15 },
                new NpvData() { Period = new DateTime(2024, 1, 1), Cashflow = 20 },
                new NpvData() { Period = new DateTime(2025, 1, 1), Cashflow = 10 },                
            };

            var actual = sut.CalculateNpv(inputs, 10, RolloverType.Annual, false);

            Assert.Equal(157.55, actual, 2);
        }

        [Fact]
        public void CalculateNpv_ForKnownMonthDateValues_ReturnsExpected()
        {
            var sut = new NpvCalculator();
            var inputs = new List<NpvData>()
            {
                new NpvData() { Period = new DateTime(2014, 1, 1), Cashflow = 25 },
                new NpvData() { Period = new DateTime(2014, 2, 1), Cashflow = 25 },
                new NpvData() { Period = new DateTime(2014, 3, 1), Cashflow = 30 },
                new NpvData() { Period = new DateTime(2014, 4, 1), Cashflow = 35 },
                new NpvData() { Period = new DateTime(2014, 5, 1), Cashflow = 20 },
                new NpvData() { Period = new DateTime(2014, 6, 1), Cashflow = 15 },
                new NpvData() { Period = new DateTime(2014, 7, 1), Cashflow = 25 },
                new NpvData() { Period = new DateTime(2014, 8, 1), Cashflow = 25 },
                new NpvData() { Period = new DateTime(2014, 9, 1), Cashflow = 15 },
                new NpvData() { Period = new DateTime(2014, 10, 1), Cashflow = 15 },
                new NpvData() { Period = new DateTime(2014, 11, 1), Cashflow = 20 },
                new NpvData() { Period = new DateTime(2014, 12, 1), Cashflow = 10 },                
            };

            var actual = sut.CalculateNpv(inputs, 10, RolloverType.Month, true);

            Assert.Equal(250.51, actual, 2);
        }

        [Fact]
        public void CalculateNpv_ForKnownQuarterDateValues_ReturnsExpected()
        {
            var sut = new NpvCalculator();
            var inputs = new List<NpvData>()
            {
                new NpvData() { Period = new DateTime(2014, 1, 1), Cashflow = 25 },
                new NpvData() { Period = new DateTime(2014, 4, 1), Cashflow = 25 },
                new NpvData() { Period = new DateTime(2014, 7, 1), Cashflow = 30 },
                new NpvData() { Period = new DateTime(2014, 10, 1), Cashflow = 35 },
                new NpvData() { Period = new DateTime(2015, 1, 1), Cashflow = 20 },
                new NpvData() { Period = new DateTime(2015, 4, 1), Cashflow = 15 },
                new NpvData() { Period = new DateTime(2015, 7, 1), Cashflow = 25 },
                new NpvData() { Period = new DateTime(2015, 10, 1), Cashflow = 25 },
                new NpvData() { Period = new DateTime(2016, 1, 1), Cashflow = 15 },
                new NpvData() { Period = new DateTime(2016, 4, 1), Cashflow = 15 },
                new NpvData() { Period = new DateTime(2016, 7, 1), Cashflow = 20 },
                new NpvData() { Period = new DateTime(2016, 10, 1), Cashflow = 10 },                
            };

            var actual = sut.CalculateNpv(inputs, 10, RolloverType.Month, true);

            Assert.Equal(232.93, actual, 2);
        }
    }
}
