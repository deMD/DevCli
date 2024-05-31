using System.CommandLine;

var root = new RootCommand();

var command = new Command("guid", "Generate a new GUID");

command.SetHandler(_ =>
{
    Console.WriteLine(Guid.NewGuid());
});

root.AddCommand(command);

return await root.InvokeAsync(args);