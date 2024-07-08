namespace GW2CraftCalculator.DependencyInjection;

public record CommandLineArgs
{
    public CommandLineArgs(string[] args) 
    {
        Args = args;
    }

    public string[] Args { get; }
}
