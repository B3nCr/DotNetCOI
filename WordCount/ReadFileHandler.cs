using System.IO;

public class ReadFileHandler
{
    public static void ReadFile(FileInfo file, bool line = false, bool byteFlag = false, bool wordFlag = false, bool characterFlag = false)
    {
        if (line)
        {
            int lineCount = File.ReadAllLines(file.FullName).Length;
            Console.WriteLine($"File {file.Name} has {lineCount} lines.");
            return;
        }

        if (byteFlag)
        {
            long byteCount = file.Length;
            Console.WriteLine($"File {file.Name} has {byteCount} bytes.");
            return;
        }

        if (wordFlag)
        {
            string content = File.ReadAllText(file.FullName);
            int wordCount = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine($"File {file.Name} has {wordCount} words.");
            return;
        }

        if (characterFlag)
        {
            string content = File.ReadAllText(file.FullName);
            int charCount = content.Length;
            Console.WriteLine($"File {file.Name} has {charCount} characters.");
            return;
        }

        Console.WriteLine($"Done Nothing.");
    }
}
