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

        // add byte count option
        var byteOption = new Option<bool>(
            aliases: new[] { "--byte", "-b" },
            description: "Return the number of bytes in the file.");

        // add word count option
        var wordOption = new Option<bool>(
            aliases: new[] { "--word", "-w" },
            description: "Return the number of words in the file.");

        // add character count option
        var charOption = new Option<bool>(
            aliases: new[] { "--char", "-c" },
            description: "Return the number of characters in the file.");

        var rootCommand = new RootCommand("Console app to read a file. Similar to the WC command.");
        rootCommand.AddOption(fileOption);
        rootCommand.AddOption(lineOption);
        rootCommand.AddOption(byteOption);
        rootCommand.AddOption(wordOption);
        rootCommand.AddOption(charOption);

        rootCommand.SetHandler((file, line, _, _, _) =>
            {
                ReadFileHandler.ReadFile(file, line);
            },
            fileOption, lineOption, byteOption, wordOption, charOption);

        return await rootCommand.InvokeAsync(args);
    }
}