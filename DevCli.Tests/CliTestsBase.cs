using System.Diagnostics;

namespace DevCli.Tests;

public class CliTestsBase
{
    protected CliTestsBase()
    {
        
    }
    
    protected static string? RunCommand(string command)
    {
        var path = AppDomain.CurrentDomain.BaseDirectory + "DevCli.exe";
        var startInfo = new ProcessStartInfo
        {
            FileName = path,
            Arguments = command,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        
        using var process = new Process();
        process.StartInfo = startInfo;
        process.Start();
        
        using var output = process.StandardOutput;
        var readOutput = output.ReadToEnd();
        process.WaitForExit();
        return readOutput.Trim();
    }
}