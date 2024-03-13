
new Exercise().Test();


Console.ReadKey();

public class Exercise
{
    public async void Test()
    {
        string data = await DownloadDataAsync("test.com", "some content");
        Console.WriteLine(data);
    }

    private async Task<string> DownloadDataAsync(string firstParam, string secondParam)
    {
        await Task.Delay(1000);
        return $"Content from URL '{firstParam}' is '{secondParam}'";
    }
}