using System;
using FluentAssertions;
using Xunit;

namespace TddByExample
{
    public class UnitTest1
    {
        //todo $5 + 10 CHF = $10 if rate is 2:1
        //todo $5 * 2 = $10
        //todo make amount private
        //todo dollar side-effects?
        //todo Money rounding?
        //todo equals !!!
        //todo getHashCode
        //todo equals null
        //todo equals object
        
        [Fact]
        public void testMultiplication()
        {
            Dollar five = new Dollar(5);
            Dollar product = five.Times(2);
            product.Amount.Should().Be(10);
            
            product = five.Times(3);
            product.Amount.Should().Be(15);
        }

        [Fact]
        public void testEquality()
        {
            new Dollar(5).Should().Be(new Dollar(5));
            new Dollar(5).Should().NotBe(new Dollar(6));
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
            return new Dollar(Amount*multiplier);
        }

        public override bool Equals(object? obj)
            => (obj as Dollar).Amount == Amount;

        public override string ToString() => Amount.ToString();
    }
}