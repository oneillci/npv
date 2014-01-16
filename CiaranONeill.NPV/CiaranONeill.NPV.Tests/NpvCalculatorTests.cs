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
            var pv = sut.CalculatePresentValue(25, 0.10d);

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
        public void CalculatePresentValue_ForThirdYearWith4Rolls_ReturnsValue()
        {
            var sut = new NpvCalculator();
            var pv = sut.CalculatePresentValue(30, 0.10d, 3, RolloverType.Quarter);

            Assert.Equal(27.85798, pv, 4);
        }

        [Fact] void CalculateNpv_ForKnownAnnualValues_ReturnsExpected()
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
                new NpvData() { Period = new DateTime(2026, 1, 1), Cashflow = 10 },
                new NpvData() { Period = new DateTime(2027, 1, 1), Cashflow = 5 },
                new NpvData() { Period = new DateTime(2028, 1, 1), Cashflow = 5 },
                new NpvData() { Period = new DateTime(2029, 1, 1), Cashflow = 5 },
                
            };

            var expected = sut.CalculateNpv(inputs, 10, RolloverType.Annual, false);

            Assert.Equal(164.05, expected, 2);
        }
    }
}
