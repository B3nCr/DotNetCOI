using System.IO;
using System.Linq;

public class ReadFileHandler
{
    public static void ReadFile(FileInfo file, bool line)
    {
        if (line)
        {
            int lineCount = File.ReadLines(file.FullName).Count();
            Console.WriteLine($"File {file.FullName} has {lineCount} lines.");
            return;
        }
        
        Console.WriteLine("Done Nothing");
    }
}
