using GW2CraftCalculator.Models.Data;

namespace GW2CraftCalculator.Models.Exceptions;
public class VendorItemCostCountMissmatchException : Exception
{
    public VendorItemCostCountMissmatchException(string? message) : base(message) { }

    public static void ThrowIfCostCountMissmatches(VendorItem vendorItem, int expectedCount)
    {
        int actualCount = vendorItem.Cost.Count;
        if (actualCount != expectedCount)
        {
            string message = $"Vendor Cost count missmatch! Id: {vendorItem.Id} | Counts: Expected={expectedCount} / Actual={actualCount}";
            throw new VendorItemCostCountMissmatchException(message);
        }
    }
}
