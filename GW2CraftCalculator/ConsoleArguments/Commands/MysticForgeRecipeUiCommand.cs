using GW2CraftCalculator.ConsoleArguments.Settings;
using GW2CraftCalculator.Interfaces;
using GW2CraftCalculator.Interfaces.Logic;
using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Models.Logic;
using GW2CraftCalculator.Models.ViewModels;
using GW2CraftCalculator.Utils.Logging;
using Microsoft.Extensions.Logging;
using Spectre.Console.Cli;

namespace GW2CraftCalculator.ConsoleArguments.Commands;

public class MysticForgeRecipeUiCommand : AsyncCommand<GuiSetting>
{
    private readonly IConsoleProcessor _consoleProcessor;
    private readonly ILogger<MysticForgeRecipeUiCommand> _logger;
    private readonly ILogicProcessor _logicProcessor;
    private readonly IMysticForgeUiFilterHandler _mysticForgeFilterHandler;

    public MysticForgeRecipeUiCommand(IConsoleProcessor consoleProcessor, ILogger<MysticForgeRecipeUiCommand> logger, ILogicProcessor logicProcessor, IMysticForgeUiFilterHandler filterHandler)
    {
        _consoleProcessor = consoleProcessor;
        _logger = logger;
        _logicProcessor = logicProcessor;
        _mysticForgeFilterHandler = filterHandler;
    }

    public async override Task<int> ExecuteAsync(CommandContext context, GuiSetting settings)
    {
        _logger.LogDebug("Gui Command is executing... (Settings: {setting})", settings.ConvertReadable());
        _consoleProcessor.WriteGreeting();

        int run = 0;
        int config = 1;
        Dictionary<int, int> runToConfig = [];

        do
        {
            MysticForgeFilter? filter;
            if (run == 0 || config == runToConfig.Values.Max() + 1)
            {
                filter = await DisplayFilter(settings);
            }
            else
            {
                filter = _mysticForgeFilterHandler.GetFilter(config);
            }

            run++;
            runToConfig.Add(run, config);
            await DisplayRecipes(settings, filter, config, run);
            config = await _consoleProcessor.Rerun(settings.Language, runToConfig);


        } while (config > 0);

        _logger.LogDebug("Gui Command finished executing.");
        return 0;
    }

    private async Task DisplayRecipes(GuiSetting settings, MysticForgeFilter? filter, int runConfig, int run)
    {
        Task<IEnumerable<ItemView>> viewModelsTask = _logicProcessor.GetPricedRecipes(settings.Language, filter, runConfig);
        Task printViewModels = _consoleProcessor.PrintViewModels(settings.Language, viewModelsTask, run);
        await _consoleProcessor.DisplayTaskProgress(settings.Language, TranslationCode.RecipeItemsLoading, viewModelsTask, printViewModels);
        await printViewModels;
    }

    private async Task<MysticForgeFilter?> DisplayFilter(GuiSetting settings)
    {
        bool? displayFilter = null;

        if (settings.Filter.IsSet)
        {
            displayFilter = !settings.Filter.Value.HasValue || settings.Filter.Value.Value;
        }

        using CancellationTokenSource tokenSource = new();
        Task<bool>? useFilter = null;
        if (displayFilter == null)
        {
            useFilter = _consoleProcessor.UseFilter(settings.Language);
        }

        MysticForgeFilter? filter = null;

        try
        {
            Task setup = _mysticForgeFilterHandler.Setup(settings.Language, tokenSource.Token);
            displayFilter ??= await useFilter!;
            if (displayFilter.Value)
            {
                await setup;
                filter = await _consoleProcessor.DisplayMysticForgeRecipeFilters(settings.Language, tokenSource.Token);
            }
            tokenSource.Cancel();
        }
        catch (OperationCanceledException) { }

        return filter;
    }
}
