namespace GW2CraftCalculator.Interfaces.Utils;
public interface IFileReader
{
    public Task<TReturn> ReadFile<TReturn>(string fileName, CancellationToken cancellationToken) where TReturn : class;
}
