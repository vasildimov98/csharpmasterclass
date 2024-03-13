using System.Text.Json;

var userConsoleInteraction = new UserConsoleInteraction();
var fileManager = new FileManager();
var gameDataParserEngine = new GameDataParserEngine(userConsoleInteraction, fileManager);

try
{
    gameDataParserEngine.Start();
}
catch (Exception ex)
{
    userConsoleInteraction.ShowMessage("Sorry! The application has experienced" +
        " an unexpected error and will have to be closed.");
    fileManager.LogException("log.txt", ex);
} 
finally
{
    userConsoleInteraction.Exit();
}


public class GameDataParserEngine
{
    private readonly IUserInteraction _userInteraction;
    private readonly IFileManager _fileManager;

    public GameDataParserEngine(IUserInteraction userInteraction, IFileManager fileManager)
    {
        this._userInteraction = userInteraction;
        this._fileManager = fileManager;
    }

    public void Start()
    {
        this._userInteraction.ShowMessage("Enter the name of the file you want to read:");

        string? fileName = null;
        while (fileName is null)
        {
            try
            {
                fileName = this._userInteraction.GetFileNameFromUser();
            }
            catch (ArgumentNullException ex)
            {
                this._userInteraction.ShowMessage(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                this._userInteraction.ShowMessage(ex.Message);
            }
            catch (ArgumentException ex)
            {
                this._userInteraction.ShowMessage(ex.Message);
            }
        }


        try
        {
            var content = this._fileManager.ReadFile(fileName);
            this._userInteraction.ShowFileContent(content);
        }
        catch (JsonException ex)
        {
            this._userInteraction.ShowMessage(ex.Message);
            this._userInteraction.ShowErrorMessage(File.ReadAllText(fileName));
            throw;
        }
    }
}

public class UserConsoleInteraction : IUserInteraction
{
    public string GetFileNameFromUser()
    {
        var userInput = Console.ReadLine();

        if (userInput is null)
        {
            throw new ArgumentNullException("File name cannot be null");
        }

        if (string.Empty == userInput)
        {
            throw new ArgumentException("File name cannot be empty");
        }

        if (!File.Exists(userInput))
        {
            throw new ArgumentOutOfRangeException("File not found");
        }

        return userInput;
    }

    public void ShowFileContent(IEnumerable<Game> content)
    {
        if (!content.Any())
        {
            this.ShowMessage("No games are present in the input file.");
            return;
        }

        foreach (var item in content)
        {
            Console.WriteLine(item);
        }
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void Exit()
    {
        this.ShowMessage("Press Any Key To Exit");
        Console.ReadKey();
    }

    public void ShowErrorMessage(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }
}

public class FileManager : IFileManager
{
    public IEnumerable<Game> ReadFile(string fileName)
    {
        var fileContent = File.ReadAllText(fileName);

        try
        {
            return JsonSerializer.Deserialize<IEnumerable<Game>>(fileContent);
        }
        catch (JsonException ex)
        {
            throw new JsonException($"JSON in the {fileName}  was not in a valid format. JSON body:", ex);
        }

    }

    public void LogException(string path,Exception ex)
    {
        var entry = @$"[{DateTime.Now}],
Exception message:{ex.InnerException.Message},
Stack trace: {ex.StackTrace},
        ";

        File.AppendAllText(path, entry);
    }
}

public interface IUserInteraction
{
    void ShowMessage(string message);

    string GetFileNameFromUser();

    void ShowFileContent(IEnumerable<Game> content);

    void Exit();
    void ShowErrorMessage(string v);
}

public interface IFileManager
{
    IEnumerable<Game> ReadFile(string fileName);
}

public class Game
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public double Rating { get; set; }

    public override string ToString()
    {
        return $"{this.Title}, released in {this.ReleaseYear}, rating: {this.Rating}";
    }
}