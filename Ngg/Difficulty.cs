using System.ComponentModel;

namespace Ngg;

public enum Difficulty
{
    [Description("Hard")]
    Hard = 3,
    [Description("Medium")]
    Medium = 5,
    [Description("Easy")]
    Easy = 10
}