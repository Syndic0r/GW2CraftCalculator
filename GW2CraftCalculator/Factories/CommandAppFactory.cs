using GW2CraftCalculator.Interfaces.Utils;
using GW2CraftCalculator.ConsoleArguments.Commands;
using GW2CraftCalculator.Interfaces;
using Microsoft.Extensions.Logging;
using Spectre.Console.Cli;
using GW2CraftCalculator.ConsoleArguments.Settings;

namespace GW2CraftCalculator.Factories;

public class CommandAppFactory : ICommandAppFactory
{
    private readonly ILogger<CommandAppFactory> _logger;
    private readonly ITypeRegistrar _typeRegistrar;
    private readonly IExceptionHandler _exceptionHandler;

    public CommandAppFactory(ILogger<CommandAppFactory> logger, ITypeRegistrar typeRegistrar, IExceptionHandler exceptionHandler)
    {
        _logger = logger;
        _typeRegistrar = typeRegistrar;
        _exceptionHandler = exceptionHandler;
    }

    public ICommandApp CreateInstance()
    {
        _logger.LogDebug("Creating Command App...");

        CommandApp commandApp = new(_typeRegistrar);
        commandApp.Configure(config =>
        {
            config.PropagateExceptions();
            config.SetExceptionHandler((e, _) => _exceptionHandler.HandleException(e));
            config.AddBranch<EmptySetting>("mysticforge", mf =>
            {
                mf.AddCommand<MysticForgeRecipeUiCommand>("ui").WithExample("mysticforge", "gui", "-l", "en", "-f");
                mf.AddCommand<MysticForgeRecipeCommand>("recipes").WithExample("mysticforge", "recipes", "-l", "en", "-f", "\"item Types=BasicItems,refined Items,fine_items, " +
                    "rareItems ;item_groups=wood,metal,totem,Blood,onyx;rarities=basic , fine,rare,EXotiC;Tiers=t2,T3,4,T5,6;Itemnames=Ore,Hard,Small,Vial of Thick,Lodestone,of_powerful\"");
            });
        });

        _logger.LogDebug("Command App created.");

        return commandApp;
    }
}
