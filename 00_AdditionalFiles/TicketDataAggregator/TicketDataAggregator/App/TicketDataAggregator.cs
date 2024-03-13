using System.Globalization;
using System.Text;

internal class TicketDataAggregator
{
	private readonly string _filePath; 
    private readonly IFileWriter _fileWriter;
    private readonly IFileReader _fileReader;
    private readonly Dictionary<string, string> domainToCulture = new ()
    {
        [".com"]  = "en-US",
        [".fr"] = "fr-FR",
        [".jp"] = "ja-JP"
    };

	public TicketDataAggregator(string path, IFileWriter fileWriter, IFileReader fileReader)
	{
		this._filePath = path;
        this._fileWriter = fileWriter;
        this._fileReader = fileReader;
	}

    internal void Run()
    {
        StringBuilder stringBulder = new StringBuilder();

        foreach (var line in this.ReadData())
        {
            stringBulder.AppendLine(line);
        }

        this._fileWriter
            .Write(Path.Combine(this._filePath, "aggragatedData.txt"),
            stringBulder.ToString());
    }

    private IEnumerable<string> ReadData()
    {
        var stringBulder = new StringBuilder();
        foreach (var fileText in this._fileReader.Read(this._filePath))
        {
            var split = fileText.Split(new string[] { "Title:", "Date:", "Time:", "Visit" }, StringSplitOptions.None);
            var domain = split.Last().ExtractDomain();

            var culture = domainToCulture[domain];
            var lines = ProccessData(split, culture);
            yield return string.Join(Environment.NewLine, lines);
        }
    }

    private static IEnumerable<string> ProccessData(string[] split, string culture)
    {
        for (int i = 1; i < split.Length - 3; i += 3)
        {
            var title = split[i];
            var date = split[i + 1];
            var time = split[i + 2];

            var dateCulture = DateOnly.Parse(date, new CultureInfo(culture));
            var timeCulture = TimeOnly.Parse(time, new CultureInfo(culture));

            yield return $"{title,-40}| {dateCulture
                .ToString(CultureInfo
                .InvariantCulture)}| {timeCulture
                .ToString(CultureInfo
                .InvariantCulture)}";
        }
    }
}
