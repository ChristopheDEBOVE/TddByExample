namespace TddByExample
{
    public class Bank
    {
        public Money reduce(Expression expression, string currency)=> expression.Reduce(currency);

        public void AddRate(string chf, string usd, int i)
        {
            
        }
    }
}