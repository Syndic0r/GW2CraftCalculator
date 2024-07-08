namespace GW2CraftCalculator.Interfaces.Utils;
public interface IEnumConverter<in TEnum, TOut> where TEnum : Enum
{
    public TOut ConvertFrom(TEnum value);
}
