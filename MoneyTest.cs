using FluentAssertions;
using Xunit;

namespace TddByExample
{
    public class MoneyTest
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
        //done dollar/franc duplication
        //done Common equals
        //done Common times !!!
        //done Compare Franc With Dollar
        //done Compare Dollars to Francs currency? 
        //done Delete testFrancMultiplication
        //todo $5+ $5= $10
        
        [Fact]
        public void TestMultiplication()
        {
            Money five = Money.Dollar(5);
            
            five.Times(2).Should().Be(Money.Dollar(10));
            five.Times(3).Should().Be(Money.Dollar(15));
        } 

        [Fact]
        public void TestEquality()
        {
            Money.Dollar(5).Should().Be(Money.Dollar(5));
            Money.Dollar(5).Should().NotBe(Money. Dollar(6));
            Money.Franc(5).Should().NotBe(Money.Dollar(5));
        } 

        [Fact]
        public void TestCurrency()
        {
            Money.Dollar(1).Currency().Should().Be("$");
            Money.Franc(1).Currency().Should().Be("CHF");
        }

        [Fact]
        public void TestSimpleAddition()
        {
            Money sum = Money.Dollar(5).plus(Money.Dollar(5));
            sum.Should().Be(Money.Dollar(10));
        }
    }
}