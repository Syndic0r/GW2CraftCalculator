using GW2CraftCalculator.DependencyInjection;
using GW2CraftCalculator.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GW2CraftCalculator;

public class Startup : IHostedService
{
    private readonly string[] _args;
    private readonly ILogger<Startup> _logger;
    private readonly ICommandAppFactory _commandAppFactory;

    public Startup(ICommandAppFactory commandAppFactory, ILogger<Startup> logger, CommandLineArgs cmdArgs)
    {
        _args = cmdArgs.Args;
        _logger = logger;
        _commandAppFactory = commandAppFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("App starting up...");
        await _commandAppFactory.CreateInstance().RunAsync(_args);
        _logger.LogInformation("App finished running.");
        //throw to exit run
        throw new OperationCanceledException();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("App stopping...");
        Log.CloseAndFlush();
    }
}
