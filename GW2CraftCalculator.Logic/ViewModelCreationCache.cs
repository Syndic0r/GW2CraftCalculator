using GW2CraftCalculator.Logic.ViewModelCreators;
using System.Diagnostics.CodeAnalysis;

namespace GW2CraftCalculator.Logic;
internal class ViewModelCreationCache
{
    internal int CurrentCreatorVersion { get => _currentCreatorVersion; }

    private ItemViewDefaultCreator _currentItemViewCreator;

    private int _currentCreatorVersion = 0;

    private Dictionary<int, ItemViewDefaultCreator> _oldItemViewCreators;

    public void SetCurrentCreator(ItemViewDefaultCreator creator)
    {
        if (_currentCreatorVersion > 0)
        {
            _oldItemViewCreators ??= [];
            _oldItemViewCreators.Add(_currentCreatorVersion, _currentItemViewCreator);
        }

        _currentCreatorVersion += 1;
        _currentItemViewCreator = creator.CacheClone(null, null, null, null);
    }

    /// <summary>
    /// Need to call <see cref="ItemViewDefaultCreator.CacheClone(IEnumerable{Gw2Sharp.WebApi.V2.Models.CommercePrices}?, IEnumerable{Gw2Sharp.WebApi.V2.Models.Item}?, IEnumerable{Models.Data.CurrencyConversion}?)"/> before using
    /// </summary>
    /// <param name="creator"></param>
    /// <returns></returns>
    internal bool TryGetCurrentCreator([NotNullWhen(true)] out ItemViewDefaultCreator? creator)
    {
        if (_currentCreatorVersion == 0)
        {
            creator = null;
            return false;
        }

        creator = _currentItemViewCreator;
        return true;
    }

    /// <summary>
    /// Need to call <see cref="ItemViewDefaultCreator.CacheClone(IEnumerable{Gw2Sharp.WebApi.V2.Models.CommercePrices}?, IEnumerable{Gw2Sharp.WebApi.V2.Models.Item}?, IEnumerable{Models.Data.CurrencyConversion}?)"/> before using
    /// </summary>
    /// <param name="version"></param>
    /// <param name="creator"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    internal bool TryGetOldCreatorVersion(int version, [NotNullWhen(true)] out ItemViewDefaultCreator? creator)
    {
        if (_currentCreatorVersion == 0)
        {
            creator = null;
            return false;
        }

        if (version <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(version), version, "Version cannot be 0 or less.");
        }

        if (version > _currentCreatorVersion)
        {
            creator = null;
            return false;
        }

        if (version == _currentCreatorVersion)
        {
            creator = _currentItemViewCreator;
            return true;
        }


        if (_oldItemViewCreators.TryGetValue(version, out creator))
        {
            return true;
        }

        return false;
    }
}
