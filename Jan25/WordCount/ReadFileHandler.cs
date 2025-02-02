using System.IO;

public static class ReadFileHandler
{
    public static void ReadFile(FileInfo file, bool countLines = false, bool countBytes = false, bool countWords = false, bool countCharacters = false)
    {
        string content = File.ReadAllText(file.FullName);
        ProcessContent(content, file.Name, countLines, countBytes, countWords, countCharacters, file.Length);
    }

    public static void ReadFromStdin(bool countLines = false, bool countBytes = false, bool countWords = false, bool countCharacters = false)
    {
        string content = Console.In.ReadToEnd();
        ProcessContent(content, "stdin", countLines, countBytes, countWords, countCharacters);
    }

    private static void ProcessContent(string content, string source, bool countLines, bool countBytes, bool countWords, bool countCharacters, long byteCount = 0)
    {
        if (string.IsNullOrEmpty(content))
        {
            Console.WriteLine("No input provided.");
            return;
        }

        if (countLines)
        {
            int lineCount = content.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            PrintResult(source, "lines", lineCount);
        }

        if (countBytes)
        {
            if (byteCount == 0)
            {
                byteCount = System.Text.Encoding.UTF8.GetByteCount(content);
            }
            PrintResult(source, "bytes", byteCount);
        }

        if (countWords)
        {
            int wordCount = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            PrintResult(source, "words", wordCount);
        }

        if (countCharacters)
        {
            int characterCount = content.Length;
            PrintResult(source, "characters", characterCount);
        }

        if (!countLines && !countBytes && !countWords && !countCharacters)
        {
            Console.WriteLine("Done Nothing.");
        }
    }

    private static void PrintResult(string source, string type, long count)
    {
        Console.WriteLine($"File {source} has {count} {type}.");
    }
}
