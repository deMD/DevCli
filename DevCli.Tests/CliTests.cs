using System.Net;
using Xunit.Abstractions;

namespace DevCli.Tests;

public class CliTests : CliTestsBase
{
    [Fact]
    public void Returns_guid()
    {   
        const string command = "guid";

        var output = RunCommand(command);
        Assert.True(Guid.TryParse(output, out _));
    }

    [Fact]
    public void Returns_ip()
    {
        const string command = "ip";

        var output = RunCommand(command);
        Assert.True(IPAddress.TryParse(output, out _));
    }
}