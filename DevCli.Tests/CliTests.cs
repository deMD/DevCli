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
}