using System;
using System.CommandLine;
using System.Threading.Tasks;

internal class Program
{
    private static async Task<Int32> Main(string[] args)
    {
        var fileOption = new Option<FileInfo>(
            aliases: new[] { "--file", "-f" },
            description: "The file to read and display on the console.");
        fileOption.IsRequired = true;

        var lineOption = new Option<bool>(
            aliases: new[] { "--line", "-l" },
            description: "Return the number of lines in the file.");

        var rootCommand = new RootCommand("Console app to read a file. Similar to the WC command.");
        rootCommand.AddOption(fileOption);
        rootCommand.AddOption(lineOption);

        rootCommand.SetHandler((file, line) =>
            {
                ReadFileHandler.ReadFile(file, line);
            },
            fileOption, lineOption);

        return await rootCommand.InvokeAsync(args);
    }
}