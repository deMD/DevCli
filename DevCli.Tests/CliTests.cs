using System.Net;
using Xunit.Abstractions;

namespace DevCli.Tests;

public class CliTests(ITestOutputHelper outputHelper) : CliTestsBase
{
    [Fact]
    public void Returns_guid()
    {   
        const string command = "guid";

        var output = RunCommand(command);
        outputHelper.WriteLine(output);
        Assert.True(Guid.TryParse(output, out _));
    }

    [Fact]
    public void Returns_ip()
    {
        const string command = "ip";

        var output = RunCommand(command);
        outputHelper.WriteLine(output);
        Assert.True(IPAddress.TryParse(output, out _));
    }
    
    [Fact]
    public void Returns_ip_if_first_url_is_invalid()
    {
        const string command = "ip";

        var output = RunCommand(command, new OverrideConfiguration
        {
            EnvironmentVariables = new Dictionary<string,string>
            {
                { "IpOptions__IpCheckUrls__0", "http://localhost" }
            } 
        });
        outputHelper.WriteLine(output);
        Assert.True(IPAddress.TryParse(output, out _));
    }
}

