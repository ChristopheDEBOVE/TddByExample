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

        public Money Reduce(Bank source, string to)=>new (
                        Addend.Reduce(source,to).Amount() 
                             + Augend.Reduce(source,to).Amount()
                            ,to);
    }
}