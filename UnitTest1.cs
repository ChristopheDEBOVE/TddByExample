using System;
using FluentAssertions;
using Xunit;

namespace TddByExample
{
    public class UnitTest1
    {
        //todo $5 + 10 CHF = $10 if rate is 2:1
        //todo $5 * 2 = $10
        
        [Fact]
        public void testMultiplication()
        {
            Dollar five = new Dollar(5);
            five.Times(2);
            five.Amount.Should().Be(10);
        }
    }
}