namespace TddByExample
{
    public class Money
    {
        private int _amount;
        private string _currency;

        private Money(int amount,string currency)
        {
            _amount = amount;
            _currency = currency;
        }

        public string Currency() => _currency;
        public override bool Equals(object? obj) =>    (obj as Money)._currency == _currency
                                                       && (obj as Money)._amount == _amount;

        public static Money Dollar(int amount)=> new(amount: amount,"$");
        public static Money Franc(int amount) => new (amount: amount,"CHF");
        public Money Times(int multiplier)    => new (_amount*multiplier,_currency);
    }
}