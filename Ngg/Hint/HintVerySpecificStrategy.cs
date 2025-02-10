using Ngg.Hint.Interfaces;

namespace Ngg.Hint;

public class HintVerySpecificStrategy : IHintStrategy
{
    public void Hint(int value)
    {
        Console.WriteLine($"Number ends with {value % 10}.\n");
    }
}