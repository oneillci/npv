using System;
using System.Linq;
using CiaranONeill.NPV.Calculator;
using Xunit;

namespace CiaranONeill.NPV.Tests
{
    public class NpvCalculatorTests
    {
        [Fact]
        public void CalculatePresentValue_ForFirstYear_ReturnsPresentValue()
        {
            var sut = new NpvCalculator();

            var pv = sut.CalculatePresentValue(25, 0.10d);

            Assert.Equal(22.7272, pv, 4);            
        }
    }
}
