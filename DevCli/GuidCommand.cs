using System.CommandLine;

namespace DevCli;

public class GuidCommand: Command, ICommand
{
    public GuidCommand() : base("guid", "Generate a new GUID")
    {
        this.SetHandler(_ =>
        {
            Console.WriteLine(Guid.NewGuid());
        });
    }
}