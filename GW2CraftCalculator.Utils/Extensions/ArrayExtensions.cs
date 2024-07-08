using System.Runtime.CompilerServices;

namespace GW2CraftCalculator.Utils.Extensions;
public static class ArrayExtensions
{
    public static T[] Add<T>(this T[] array, T value)
    {
        T[] newArray = new T[array.Length + 1];
        array.CopyTo(newArray, 0);
        newArray[array.Length] = value;
        array = newArray;
        return array;
    }

    public static T[] AddRange<T>(this T[] array, T[] values)
    {
        if (values == Array.Empty<T>())
        {
            return array;
        }

        foreach (T value in values)
        {
            array = array.Add(value);
        }
        return array;
    }
}
