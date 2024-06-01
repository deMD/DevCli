using System.Diagnostics;

namespace DevCli.Tests;

public class CliTestsBase
{
    protected CliTestsBase()
    {
        
    }
    
    protected static string? RunCommand(string command, OverrideConfiguration? overrideConfiguration = null)
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

        if (overrideConfiguration is { EnvironmentVariables: not null })
        {
            foreach (var environmentVariable in overrideConfiguration.EnvironmentVariables)
            {
                startInfo.EnvironmentVariables[environmentVariable.Key] = environmentVariable.Value;
            }
        }
        
        using var process = new Process();
        process.StartInfo = startInfo;
        process.Start();
        
        using var output = process.StandardOutput;
        var readOutput = output.ReadToEnd();
        process.WaitForExit();
        return readOutput.Trim();
    }
}

public record OverrideConfiguration(Dictionary<string, string>? EnvironmentVariables = null);