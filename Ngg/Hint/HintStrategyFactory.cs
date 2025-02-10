using Ngg.Hint.Interfaces;

namespace Ngg.Hint;

public class HintStrategyFactory
{
    public IHintStrategy CreateHintStrategy(HintType type)
    {
        return type switch
        {
            HintType.Broad => new HintBroadStrategy(),
            HintType.Specific => new HintSpecificStrategy(),
            HintType.VerySpecific => new HintVerySpecificStrategy(),
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };
    }
}