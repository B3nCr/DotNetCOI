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

        var stdinOption = new Option<bool>(
            aliases: new[] { "--stdin", "-s" },
            description: "Read from standard input.");

        var lineOption = new Option<bool>(
            aliases: new[] { "--line", "-l" },
            description: "Return the number of lines in the file.");

        var byteOption = new Option<bool>(
            aliases: new[] { "--byte", "-b" },
            description: "Return the number of bytes in the file.");

        var wordOption = new Option<bool>(
            aliases: new[] { "--word", "-w" },
            description: "Return the number of words in the file.");

        var charOption = new Option<bool>(
            aliases: new[] { "--char", "-c" },
            description: "Return the number of characters in the file.");

        var rootCommand = new RootCommand("Console app to read a file. Similar to the WC command.");
        rootCommand.AddOption(fileOption);
        rootCommand.AddOption(stdinOption);
        rootCommand.AddOption(lineOption);
        rootCommand.AddOption(byteOption);
        rootCommand.AddOption(wordOption);
        rootCommand.AddOption(charOption);

        rootCommand.SetHandler((file, stdin, line, byteFlag, wordFlag, charFlag) =>
            {
                if (stdin)
                {
                    ReadFileHandler.ReadFromStdin(line, byteFlag, wordFlag, charFlag);
                }
                else
                {
                    ReadFileHandler.ReadFile(file, line, byteFlag, wordFlag, charFlag);
                }
            },
            fileOption, stdinOption, lineOption, byteOption, wordOption, charOption);

        return await rootCommand.InvokeAsync(args);
    }
}