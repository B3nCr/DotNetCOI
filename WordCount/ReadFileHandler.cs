using System.IO;

public class ReadFileHandler
{
    public static void ReadFile(FileInfo file, bool countLines = false, bool countBytes = false, bool countWords = false, bool countCharacters = false)
    {
        string content = File.ReadAllText(file.FullName);

        if (countLines)
        {
            int lineCount = content.Split('\n').Length;
            Console.WriteLine($"File {file.Name} has {lineCount} lines.");
        }

        if (countBytes)
        {
            long byteCount = file.Length;
            Console.WriteLine($"File {file.Name} has {byteCount} bytes.");
        }

        if (countWords)
        {
            int wordCount = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine($"File {file.Name} has {wordCount} words.");
        }

        if (countCharacters)
        {
            int charCount = content.Length;
            Console.WriteLine($"File {file.Name} has {charCount} characters.");
        }

        if (!countLines && !countBytes && !countWords && !countCharacters)
        {
            Console.WriteLine("Done Nothing.");
        }
    }

    public static void ReadFromStdin(bool countLines = false, bool countBytes = false, bool countWords = false, bool countCharacters = false)
    {
        string content = Console.In.ReadToEnd();

        if (countLines)
        {
            int lineCount = content.Split('\n').Length;
            Console.WriteLine($"Input has {lineCount} lines.");
        }

        if (countBytes)
        {
            long byteCount = System.Text.Encoding.UTF8.GetByteCount(content);
            Console.WriteLine($"Input has {byteCount} bytes.");
        }

        if (countWords)
        {
            int wordCount = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine($"Input has {wordCount} words.");
        }

        if (countCharacters)
        {
            int charCount = content.Length;
            Console.WriteLine($"Input has {charCount} characters.");
        }

        if (!countLines && !countBytes && !countWords && !countCharacters)
        {
            Console.WriteLine("Done Nothing.");
        }
    }
}
