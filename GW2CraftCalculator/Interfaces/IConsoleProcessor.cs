using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Models.Logic;
using GW2CraftCalculator.Models.ViewModels;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace GW2CraftCalculator.Interfaces;

public interface IConsoleProcessor
{
    public void WriteGreeting();
    public Task DisplayTaskProgress(Language language, TranslationCode loadingDescription, params Task[] tasks);
    public Task PrintViewModels(Language language, Task<IEnumerable<ItemView>> viewModelsTask, int run);
    public Task<bool> UseFilter(Language language);
    public Task<MysticForgeFilter> DisplayMysticForgeRecipeFilters(Language language, CancellationToken cancellationToken);
    public Task<int> Rerun(Language language, Dictionary<int, int> runToConfigMap);
    public void WriteColoredText(string text, Color color, string? lineEnding = null, string? link = null);
    public void WriteRenderables(params IRenderable[] renderables);
    public string CorrectMarkupText(string text);
}
