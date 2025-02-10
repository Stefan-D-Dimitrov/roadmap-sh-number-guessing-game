using Ngg.Hint.Interfaces;

namespace Ngg.Hint;

public class HintSpecificStrategy : IHintStrategy
{
    public void Hint(int value)
    {
        var values = new[] { 13, 7, 5, 3 };

        foreach (var item in values)
        {
            if (value % item == 0)
            {
                Console.WriteLine($"Number is divisible by {item}.\n");
            }
        }
    }
}