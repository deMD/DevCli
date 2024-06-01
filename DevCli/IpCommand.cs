using System.CommandLine;
using System.Net;
using Microsoft.Extensions.Options;

namespace DevCli;

public class IpCommand : Command, ICommand
{
    public IpCommand(IOptionsMonitor<IpCommandOptions> options) : base("ip", "Get your external IP address")
    {
        this.SetHandler(async _ =>
        {
            using var client = new HttpClient();

            var urls = options.CurrentValue.IpCheckUrls;
            foreach (var url in urls)
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode ||
                    !IPAddress.TryParse(await response.Content.ReadAsStringAsync(), out var ipAddress))
                {
                    continue;
                }
                Console.WriteLine(ipAddress);
                break;
            }
        });
    }
}