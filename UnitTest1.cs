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
        //done Common equals
        //todo Common times
        //done Compare Franc With Dollar
        //todo Compare Dollars to Francs currency? !!!
        //todo Delete testFrancMultiplication
        
        [Fact]
        public void testMultiplication()
        {
            Money five = Money.Dollar(5);
            
            five.Times(2).Should().Be(Money.Dollar(10));
            five.Times(3).Should().Be(Money.Dollar(15));
        }
        
        [Fact]
        public void testFrancMultiplication()
        {
            Money five = Money.Franc(5);
            
            five.Times(2).Should().Be(Money.Franc(10));
            five.Times(3).Should().Be(Money.Franc(15));
        }

        [Fact]
        public void testEquality()
        {
            Money.Dollar(5).Should().Be(Money.Dollar(5));
            Money.Dollar(5).Should().NotBe(Money. Dollar(6));
            
            Money.Franc(5).Should().Be(Money.Franc(5));
            Money.Franc(5).Should().NotBe(Money.Franc(6));
            
            Money.Franc(5).Should().NotBe(Money.Dollar(5));
        }
    }

    public abstract class Money
    {
        protected int amount;
        
        
        public override bool Equals(object? obj)
            => obj.GetType() == GetType() && (obj as Money).amount == amount;

        public static Money Dollar(int amount)=>new Dollar(amount: amount);
        public static Money Franc(int amount)=>new Franc(amount: amount);
        public abstract Money Times(int multiplier);

    }

    public class Dollar : Money
    {
        public Dollar(int amount)
        {
            this.amount = amount;
        }

        public override Money Times(int multiplier)
        {
            return new Dollar(amount*multiplier);
        }
    }
    
    public class Franc : Money
    {
        public Franc(int amount)
        {
            this.amount = amount;
        }
        

        public override Money Times(int multiplier)
        {
            return new Franc(amount*multiplier);
        }
    }
}