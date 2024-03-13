var cvsReader = new CVSReader(@"C:\Users\vasil\Downloads\sampleData.csv").Read();

Console.ReadKey();

public class CVSReader
{
    private readonly string _filePath;

    public CVSReader(string filePath)
    {
        this._filePath = filePath;
    }

    public CVSData Read()
    {
        using var streamReader = new StreamReader(this._filePath, true);

        var Seperator = ",";
        var colums = streamReader.ReadLine().Split(Seperator);

        var cvsData = new CVSData();
        
        cvsData.Colums = colums;

        var currRows = new List<string[]>();
        while (!streamReader.EndOfStream)
        {
            var currRow = streamReader.ReadLine().Split(Seperator);

            currRows.Add(currRow);
        }

        cvsData.Row= currRows;

        return cvsData;
    }
}

public class CVSData
{
    public string[] Colums { get; set; }

    public IEnumerable<string[]> Row { get; set; }
}