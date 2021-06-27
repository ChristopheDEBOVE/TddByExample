using System;
using FluentAssertions;
using Xunit;

namespace TddByExample
{
    public class UnitTest1
    {
        //todo $5 + 10 CHF = $10 if rate is 2:1
        //todo $5 * 2 = $10
        //todo make amount private !!!
        //todo dollar side-effects?
        //todo Money rounding?
        //todo equals
        //todo getHashCode
        //todo equals null
        //todo equals object
        
        [Fact]
        public void testMultiplication()
        {
            Dollar five = new Dollar(5);
            
            five.Times(2).Should().Be(new Dollar(10));
            five.Times(3).Should().Be(new Dollar(15));
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
            this._amount = amount;
        }

        private int _amount;

        public Dollar Times(int multiplier)
        {
            return new Dollar(_amount*multiplier);
        }

        public override bool Equals(object? obj)
            => (obj as Dollar)._amount == _amount;

        public override string ToString() => _amount.ToString();
    }
}