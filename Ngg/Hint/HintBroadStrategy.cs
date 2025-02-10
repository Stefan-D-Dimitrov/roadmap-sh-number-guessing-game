using Ngg.Hint.Interfaces;

namespace Ngg.Hint;

public class HintBroadStrategy : IHintStrategy
{
    public void Hint(int value)
    {
        Console.WriteLine($"Value is {(value % 2 == 0 ? "even":"odd")}.\n");
    }
}