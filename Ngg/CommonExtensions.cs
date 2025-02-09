namespace Ngg;

public static class CommonExtensions
{
    public static int ToInt32<T>(this T value) where T : Enum
    {
        return Convert.ToInt32(value);
    }
    
    public static T ToEnum<T>(this int value) where T : Enum
    {
        if (Enum.IsDefined(typeof(T), value))
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        throw new ArgumentOutOfRangeException(value.ToString());
    }
}