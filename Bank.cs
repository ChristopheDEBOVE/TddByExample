using System;
using System.Collections.Generic;

namespace TddByExample
{
    public class Bank
    {
        private class Pair
        {
            private string from;
            private string to;

            public Pair(string @from, string to)
            {
                this.@from = @from;
                this.to = to;
            }

            protected bool Equals(Pair other)
            {
                return @from == other.@from && to == other.to;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Pair) obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(@from, to);
            }
        }

        public Money reduce(Expression expression, string currency)=> expression.Reduce(this,currency);
        private Dictionary<Pair, int> ChangeRate = new();
            
        public void AddRate(string @from, string to, int rate)
        {
            ChangeRate.TryAdd(new Pair(@from, to), rate);
            ChangeRate.TryAdd(new Pair(to, from), 1/rate);
        }

        public int Rate(string currency, string to)
        {
            if (currency == to) return 1;
            var pair = new Pair(currency, to);
            return ChangeRate[pair];
        }
    }
}