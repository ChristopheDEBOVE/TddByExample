using System;
using FluentAssertions;
using Xunit;

namespace TddByExample
{
    public class UnitTest1
    {
        //todo $5 + 10 CHF = $10 if rate is 2:1
        //todo $5 * 2 = $10 !!!
        //todo make amount private
        //todo dollar side-effects? !!!
        //todo Money rounding?
        
        [Fact]
        public void testMultiplication()
        {
            Dollar five = new Dollar(5);
            five.Times(2);
            five.Amount.Should().Be(10);
            
            five.Times(3);
            five.Amount.Should().Be(15);
        }
    }
    

    public class Dollar
    {
        public Dollar(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; set; } = 10;

        public void Times(int multiplier)
        {
            Amount *= multiplier;
        }
    }
}