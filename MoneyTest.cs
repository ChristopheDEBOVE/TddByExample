using System.Linq.Expressions;
using FluentAssertions;
using Xunit;

namespace TddByExample
{
    public class MoneyTest
    {
        //todo $5 + 10 CHF = $10 if rate is 2:1
        //todo Money rounding?
        //todo getHashCode
        //todo equals null
        //todo equals object 
        //todo $5+ $5= $10
        
        [Fact]
        public void TestMultiplication()
        {
            Money five = Money.Dollar(5);
            
            five.Times(2).Should().Be(Money.Dollar(10));
            five.Times(3).Should().Be(Money.Dollar(15));
        } 
        
        [Fact]
        public void TestMixedAddition()
        {
            //todo $5 + 10 CHF = $10 if rate is 2:1
            Bank bank = new Bank();
            bank.AddRate("CHF","USD",2);
            
            Assert.Equal(Money.Dollar(10),
            Money.Dollar(5)
                .plus(Money.Franc(10))
                .Reduce(bank,"USD"));
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
            Money.Dollar(1).Currency().Should().Be("USD");
            Money.Franc(1).Currency().Should().Be("CHF");
        }

        [Fact]
        public void TestSimpleAddition()
        {
            var five = Money.Dollar(5);
            Expression sum = five.plus(five);
            Bank bank = new Bank();
            Money reduced = bank.reduce(sum, "USD");
            reduced.Should().Be(Money.Dollar(10));
        }
        
        [Fact]
        public void TestReduceSumAddition()
        {
            Expression sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            Bank bank = new Bank();
            Money reduced = bank.reduce(sum, "USD");
            reduced.Should().Be(Money.Dollar(7));
        }
        
        [Fact]
        public void TestPlusMustBeASum()
        {
            var five = Money.Dollar(5);
            Expression result = five.plus(five);
            Sum sum = (Sum) result;
            sum.Augend.Should().Be(five);
            sum.Addend.Should().Be(five);
        }
        
        [Fact]
        public void TestReduceMoneyDifferentCurrency()
        {
            Bank bank = new Bank();
            bank.AddRate("CHF","USD",2);
            bank.reduce(Money.Franc(2), "USD")
                .Should().Be(Money.Dollar(1));

        }
        
        [Fact]
        public void TestIdentityRate()
        {
            new Bank().Rate("USD","USD").Should().Be(1);
        }
    }
}