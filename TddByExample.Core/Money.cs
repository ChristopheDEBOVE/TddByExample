using System;

namespace TddByExample.Core
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

        protected bool Equals(Money other)
        {
            return Amount == other.Amount && Currency == other.Currency;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

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