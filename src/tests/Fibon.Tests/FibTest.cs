using System;
using Fibon.Service.Handlers;
using Xunit;

namespace Fibon.Tests
{
    public class FibTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        public void Fib_ReturnCorrectValues(int number, int expectedResult)
        {
            ICalculator calc = new Calculator();
            var result = calc.Fib(number);

            Assert.Equal(expectedResult, result);
        }
    }
}
