using System;
using System.Collections.Generic;

namespace TddByExample.Core
{
    public class Bank
    {
        public Money Reduce(Expression expression, string currency)=> expression.Reduce(this,currency);
        private readonly Dictionary<Pair, int> _changeRate = new();
            
        public void AddRate(string @from, string to, int rate)
        {
            _changeRate.TryAdd(new Pair(@from, to), rate);
            _changeRate.TryAdd(new Pair(to, from), 1/rate);
        }

        public int Rate(string currency, string to)
        {
            if (currency == to) return 1;
            var pair = new Pair(currency, to);
            return _changeRate[pair];
        }
        
        private class Pair
        {
            private readonly string _from;
            private readonly string _to;

            public Pair(string @from, string to)
            {
                this._from = @from;
                this._to = to;
            }

            protected bool Equals(Pair other)
            {
                return _from == other._from && _to == other._to;
            }

            public override bool Equals(object? obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Pair) obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(_from, _to);
            }
        }
    }
}