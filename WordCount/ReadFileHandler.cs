using System.IO;

public class ReadFileHandler
{
    public static void ReadFile(FileInfo file, bool line)
    {
        if(line){
            file.ReadFile(file).Lines

            return 
        }
        File.ReadLines(file.FullName).ToList()
            .ForEach(line => Console.WriteLine(line));
        console.WriteLine();

        Console.WriteLine($"File {file.FullName} has been read.");
    }
}
