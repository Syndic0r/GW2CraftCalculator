using GW2CraftCalculator.Interfaces.Data;
using GW2CraftCalculator.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GW2CraftCalculator.Data.DependencyInjection;

public static class DependecyInjection
{
    public static HostApplicationBuilder AddDataServices(this HostApplicationBuilder builder)
    {
        string connectionString = builder.Configuration.GetConnectionString("Default")!;

        string? appNameArg = builder.Configuration["applicationName"];

        //change db location for running migrations
        if (!string.IsNullOrEmpty(appNameArg))
        {
            string[] splitConnString = connectionString.Split("=");
            connectionString = splitConnString[0] + " = ..\\GW2CraftCalculator.Data\\" + splitConnString[1];
        }

        builder.Services.AddDbContextFactory<Gw2DataContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        builder.Services.AddSingleton<IItemsRepository, ItemsRepository>();

        return builder;
    }
}
