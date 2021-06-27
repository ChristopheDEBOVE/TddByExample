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
            Dollar product = five.Times(2);
            product.Amount.Should().Be(10);
            
            product = five.Times(3);
            product.Amount.Should().Be(15);
        }
    }
    

    public class Dollar
    {
        public Dollar(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; set; } = 10;

        public Dollar Times(int multiplier)
        {
            Amount *= multiplier;
            return null;
        }
    }
}