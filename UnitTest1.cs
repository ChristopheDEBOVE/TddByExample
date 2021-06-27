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
        //todo Common times !!!
        //done Compare Franc With Dollar
        //done Compare Dollars to Francs currency? 
        //todo Delete testFrancMultiplication
        
        [Fact]
        public void testMultiplication()
        {
            Money five = Money.Dollar(5);
            
            five.Times(2).Should().Be(Money.Dollar(10));
            five.Times(3).Should().Be(Money.Dollar(15));
        } 

        [Fact]
        public void testEquality()
        {
            Money.Dollar(5).Should().Be(Money.Dollar(5));
            Money.Dollar(5).Should().NotBe(Money. Dollar(6));
            Money.Franc(5).Should().NotBe(Money.Dollar(5));
        } 

        [Fact]
        public void testCurrency()
        {
            Money.Dollar(1).Currency().Should().Be("$");
            Money.Franc(1).Currency().Should().Be("CHF");
        }
    }

    public class Money
    {
        protected int amount;
        protected string currency;

        public Money(int amount,string currency)
        {
            this.amount = amount;
            this.currency = currency;
        }
        
        public string Currency() => currency;

        public override bool Equals(object? obj)
            =>    (obj as Money).currency == currency
               && (obj as Money).amount == amount;

        public static Money Dollar(int amount)=> new Money(amount: amount,"$");
        public static Money Franc(int amount)=> new Money(amount: amount,"CHF");
        
        public Money Times(int multiplier)=> new (amount*multiplier,currency);

    }

}