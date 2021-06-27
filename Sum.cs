namespace TddByExample
{
    public class Sum : Expression
    {
        public Money Augend { get; }
        public Money Addend { get; }

        public Sum(Money augend, Money addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(string to)
        {
            return new Money(Addend.Amount() + Augend.Amount(),to);
        }
    }
}