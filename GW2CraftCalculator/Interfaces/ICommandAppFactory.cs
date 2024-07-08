using Spectre.Console.Cli;

namespace GW2CraftCalculator.Interfaces;

public interface ICommandAppFactory
{
    public ICommandApp CreateInstance();
}
