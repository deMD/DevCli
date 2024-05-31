using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevCli;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var configuration = new ConfigurationManager();
        configuration.AddJsonFile("appsettings.json", optional: false);
        configuration.AddEnvironmentVariables();

        var services = new ServiceCollection();
        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<Application>();
        services.AddTransient<ICommand, GuidCommand>();
        services.AddTransient<ICommand, IpCommand>();
        var provider = services.BuildServiceProvider();
        var app = provider.GetRequiredService<Application>();
        await app.RunAsync(args);
    }
}