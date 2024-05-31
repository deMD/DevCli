using System.CommandLine;

namespace DevCli;

internal class Application(IEnumerable<ICommand> commands)
{
    public async Task RunAsync(string[] args)
    {
        var root = new RootCommand("Commandline tools for developers!");
    
        foreach (var command in commands)
        {
            root.AddCommand((Command)command);
        }

        await root.InvokeAsync(args);
    }
}