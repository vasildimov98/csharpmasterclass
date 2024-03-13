var names = new Names();
var path = Names.BuildFilePath();
var repository = new StringTextualRepository();

if(File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");
    var allNames = repository.Read(path);
    names.AddAllNames(allNames);
}
else
{
    Console.WriteLine("Names file does not yet exist.");

    //let's imagine they are given by the user
    names.AddName("John");
    names.AddName("not a valid name");
    names.AddName("Claire");
    names.AddName("123 definitely not a valid name");

    Console.WriteLine("Saving names to the file.");
    repository.Write(path, names.All);
}
Console.WriteLine(names.Format());

Console.ReadKey();

public class StringTextualRepository
{
    public readonly string Seperator = Environment.NewLine;

    public List<string> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        return fileContents.Split(Seperator).ToList();
    }

    public void Write(string filePath, List<string> names) =>
        File.WriteAllText(filePath, string.Join(Seperator, names));
}

public static class NameValidator
{
    public static bool IsValid(string name)
    {
        return
            name.Length >= 2 &&
            name.Length < 25 &&
            char.IsUpper(name[0]) &&
            name.All(char.IsLetter);
    }
}

public class Names
{
    public List<string> All { get; } = new List<string>();

    internal void AddAllNames(List<string> allNames)
    {
        foreach(var name in allNames)
        {
            this.AddName(name);
        }
    }

    public void AddName(string name)
    {
        if (NameValidator.IsValid(name))
        {
            this.All.Add(name);
        }
    }

    public static string BuildFilePath()
    {
        //we could imagine this is much more complicated
        //for example that path is provided by the user and validated
        return "names.txt";
    }

    public string Format() =>
        string.Join(Environment.NewLine, this.All);

    
}
