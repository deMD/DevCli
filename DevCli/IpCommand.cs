using System.CommandLine;
using Microsoft.Extensions.Configuration;

namespace DevCli;

public class IpCommand : Command, ICommand
{
    public IpCommand(IConfiguration configuration) : base("ip", "Get your external IP address")
    {
        this.SetHandler(async _ =>
        {
            using var client = new HttpClient();
            var ip = client.GetAsync(configuration.GetSection("IpCheckUrls").Get<string[]>()[0]);
            Console.WriteLine(await ip.Result.Content.ReadAsStringAsync());
        });
    }
}