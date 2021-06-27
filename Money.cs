using System.Linq.Expressions;

namespace TddByExample
{
    public class Money : Expression
    {
        public readonly int Amount;
        public readonly string Currency;

        public Money(int amount,string currency)
        {
            Amount = amount;
            Currency = currency;
        }

         
        public override bool Equals(object? obj) =>    (obj as Money).Currency == Currency
                                                       && (obj as Money).Amount == Amount;

        public Money Reduce(Bank source, string to)
        {
            return new Money(Amount / source.Rate(Currency,to), to);
        }

        public static Money Dollar(int amount)=> new(amount: amount,"USD");
        public static Money Franc(int amount) => new (amount: amount,"CHF");
        public Expression Times(int multiplier)    => new Money(Amount*multiplier,Currency);

        public Sum Plus(Expression addend)
        {
            return new (this,addend);
        }

        public override string ToString() => Amount+ " " + Currency;
    }
}