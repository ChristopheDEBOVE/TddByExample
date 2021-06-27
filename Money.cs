using System.Linq.Expressions;

namespace TddByExample
{
    public class Money : Expression
    {
        private int _amount;
        private string _currency;

        public Money(int amount,string currency)
        {
            _amount = amount;
            _currency = currency;
        }

        public string Currency() => _currency;
        public int Amount() => _amount;
        public override bool Equals(object? obj) =>    (obj as Money)._currency == _currency
                                                       && (obj as Money)._amount == _amount;

        public Money Reduce(string to)
        {
            int rate = to == "USD" && Currency() == "CHF"
                ? 2
                : 1;
            return new Money(_amount / rate, to);
        }

        public static Money Dollar(int amount)=> new(amount: amount,"USD");
        public static Money Franc(int amount) => new (amount: amount,"CHF");
        public Money Times(int multiplier)    => new (_amount*multiplier,_currency);

        public Sum plus(Money addend)
        {
            return new Sum(this,addend);
        }
    }
}