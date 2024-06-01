using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevCli;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var configuration = ConfigureConfiguration();
        var provider = ConfigureServices(configuration);
        var app = provider.GetRequiredService<Application>();
        await app.RunAsync(args);
    }

    private static ConfigurationManager ConfigureConfiguration()
    {
        var configuration = new ConfigurationManager();
        configuration.AddJsonFile("appsettings.json", optional: false);
        configuration.AddEnvironmentVariables();
        return configuration;
    }

    private static ServiceProvider ConfigureServices(ConfigurationManager configuration)
    {
        var services = new ServiceCollection();
        services.Configure<IpCommandOptions>(configuration.GetSection(IpCommandOptions.Section));
        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<Application>();
        services.AddTransient<ICommand, GuidCommand>();
        services.AddTransient<ICommand, IpCommand>();
        var provider = services.BuildServiceProvider();
        return provider;
    }
}