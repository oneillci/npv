using System;
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
    }
}
