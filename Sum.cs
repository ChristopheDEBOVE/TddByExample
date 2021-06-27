namespace TddByExample
{
    public class Sum : Expression
    {
        public Expression Augend { get; }
        public Expression Addend { get; }

        public Sum(Expression augend, Expression addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(Bank source, string to)=>new (
                        Addend.Reduce(source,to).Amount 
                             + Augend.Reduce(source,to).Amount,to);
    }
}