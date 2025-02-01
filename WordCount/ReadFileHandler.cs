using System.IO;

public class ReadFileHandler
{
    public static void ReadFile(FileInfo file, bool line = false, bool byteFlag = false)
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

        Console.WriteLine($"Done Nothing.");
    }
}
