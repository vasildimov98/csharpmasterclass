public class FileWriter : IFileWriter
{
    public void Write(string path, string text)
    {
        File.WriteAllText(path, text);
        Console.WriteLine($"Successfully saved data to path: {path}");
    }
}
