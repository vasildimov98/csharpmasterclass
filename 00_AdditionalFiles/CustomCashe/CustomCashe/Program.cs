using System.Collections;

IDataDownloader dataDownloader = new CacheDataDownloader(
                                    new PrintingDataDownloader(
                                        new SlowDataDownloader()));

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));


Console.ReadKey();

public class PrintingDataDownloader : IDataDownloader
{
    private readonly IDataDownloader _dataDownloader;

    public PrintingDataDownloader(IDataDownloader dataDownloader)
    {
        this._dataDownloader = dataDownloader;
    }

    public string DownloadData(string resourceId)
    {
        var data = this._dataDownloader.DownloadData(resourceId);
        Console.WriteLine("Data is ready");
        return data;
    }
}

public class CacheDataDownloader : IDataDownloader
{
    private readonly IDataDownloader _dataDownloader;
    private readonly CustomDicCache<string, string> _cache = new();

    public CacheDataDownloader(IDataDownloader dataDownloader)
    {
          this._dataDownloader = dataDownloader;
    }

    public string DownloadData(string resourceId)
    {
       return this._cache.Get(resourceId, this._dataDownloader.DownloadData);
    }
}


public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}

public class CustomDicCache<TKey, TValue> 
{
   private Dictionary<TKey, TValue> _dataStore = new Dictionary<TKey, TValue>();

    public TValue Get(TKey resourceId, Func<TKey, TValue> getElementForTheFirstTime)
    {
        if (!this._dataStore.ContainsKey(resourceId))
        {
            this._dataStore[resourceId] = getElementForTheFirstTime(resourceId);
        }

        return this._dataStore[resourceId];
    }
}
