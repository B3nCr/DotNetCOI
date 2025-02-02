using System.IO;

public class ReadFileHandler
{
    public static void ReadFile(FileInfo file, bool line = false, bool byteFlag = false, bool wordFlag = false, bool characterFlag = false)
    {
        string content = File.ReadAllText(file.FullName);

        if (line)
        {
            int lineCount = content.Split('\n').Length;
            Console.WriteLine($"File {file.Name} has {lineCount} lines.");
        }

        if (byteFlag)
        {
            long byteCount = file.Length;
            Console.WriteLine($"File {file.Name} has {byteCount} bytes.");
        }

        if (wordFlag)
        {
            int wordCount = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine($"File {file.Name} has {wordCount} words.");
        }

        if (characterFlag)
        {
            int charCount = content.Length;
            Console.WriteLine($"File {file.Name} has {charCount} characters.");
        }

        if (!line && !byteFlag && !wordFlag && !characterFlag)
        {
            Console.WriteLine("Done Nothing.");
        }
    }

    public static void ReadFromStdin(bool line = false, bool byteFlag = false, bool wordFlag = false, bool characterFlag = false)
    {
        string content = Console.In.ReadToEnd();

        if (line)
        {
            int lineCount = content.Split('\n').Length;
            Console.WriteLine($"Input has {lineCount} lines.");
        }

        if (byteFlag)
        {
            long byteCount = System.Text.Encoding.UTF8.GetByteCount(content);
            Console.WriteLine($"Input has {byteCount} bytes.");
        }

        if (wordFlag)
        {
            int wordCount = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine($"Input has {wordCount} words.");
        }

        if (characterFlag)
        {
            int charCount = content.Length;
            Console.WriteLine($"Input has {charCount} characters.");
        }

        if (!line && !byteFlag && !wordFlag && !characterFlag)
        {
            Console.WriteLine("Done Nothing.");
        }
    }
}
