using System.Reflection;

namespace GW2CraftCalculator.Utils.Extensions;
public static class EnumExtensions
{
    public static TReturn GetEnumAttributeValue<TEnum, TAttribute, TReturn>(this TEnum enumVal, Func<TAttribute, TReturn> attributeValueSelection)
        where TEnum : struct, Enum
        where TAttribute : Attribute
    {
        Type enumType = typeof(TEnum);
        MemberInfo memberInfo = enumType.GetMember(enumVal.ToString())
                                .First(m => m.DeclaringType == enumType);

        TAttribute? attribute = memberInfo.GetCustomAttribute(typeof(TAttribute), false) as TAttribute;
        ArgumentNullException.ThrowIfNull(attribute);

        return attributeValueSelection(attribute);
    }

    public static IEnumerable<string> GetExpectedValues<T>(string valueNameSeperator = " - ", params T[] excludeValues) where T : struct, Enum
    {

        IEnumerable<string> expectedEnumValues = Enum.GetValues<T>()
                                                    .Where(v => !excludeValues.Contains(v))
                                                    .Select(v => $"{Convert.ToInt32(v)}{valueNameSeperator}{v}");
        return expectedEnumValues;
    }
}
