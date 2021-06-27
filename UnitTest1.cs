using System;
using FluentAssertions;
using Xunit;

namespace TddByExample
{
    public class UnitTest1
    {
        //todo $5 + 10 CHF = $10 if rate is 2:1
        //done $5 * 2 = $10
        //done make amount private 
        //done dollar side-effects?
        //todo Money rounding?
        //done equals
        //todo getHashCode
        //todo equals null
        //todo equals object
        //done 5 CHF * 2 = 10 CHF
        //todo dollar/franc duplication
        //todo Common equals
        //todo Common times !!!
        
        
        [Fact]
        public void testMultiplication()
        {
            Dollar five = new Dollar(5);
            
            five.Times(2).Should().Be(new Dollar(10));
            five.Times(3).Should().Be(new Dollar(15));
        }
        
        [Fact]
        public void testFrancMultiplication()
        {
            Franc five = new Franc(5);
            
            five.Times(2).Should().Be(new Franc(10));
            five.Times(3).Should().Be(new Franc(15));
        }

        [Fact]
        public void testEquality()
        {
            new Dollar(5).Should().Be(new Dollar(5));
            new Dollar(5).Should().NotBe(new Dollar(6));
            
            new Franc(5).Should().Be(new Franc(5));
            new Franc(5).Should().NotBe(new Franc(6));
        }
    }

    public class Money
    {
        protected int amount;
        
        public override bool Equals(object? obj)
            => (obj as Money).amount == amount;
    }

    public class Dollar : Money
    {
        public Dollar(int amount)
        {
            this.amount = amount;
        }

        public Dollar Times(int multiplier)
        {
            return new Dollar(amount*multiplier);
        }
        public override string ToString() => amount.ToString();
    }
    
    public class Franc
    {
        public Franc(int amount)
        {
            this._amount = amount;
        }

        private int _amount;

        public Franc Times(int multiplier)
        {
            return new Franc(_amount*multiplier);
        }

        public override bool Equals(object? obj)
            => (obj as Franc)._amount == _amount;

        public override string ToString() => _amount.ToString();
    }
}