using TddByExample.Core;

namespace TddByExample
{
    public interface Expression
    {
        Money Reduce(Bank source, string to);
    }
}