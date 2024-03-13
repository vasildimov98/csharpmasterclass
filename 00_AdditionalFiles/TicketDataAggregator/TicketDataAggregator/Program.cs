//var path = @"C:\Users\vasil\Downloads\Tickets";

//try
//{
//	var number = 100;

//	Console.WriteLine($"{number:C}");

//	var fileWriter = new FileWriter();
//	var fileReader = new PDFFileReader();
//	var ticketDataAggregator = new TicketDataAggregator(path, fileWriter, fileReader);

//	ticketDataAggregator.Run();

//    Console.ReadKey();
//}
//catch (Exception ex)
//{
//	Console.WriteLine($"An Exception occured! Exception message: {ex.Message}");
//}


Console.ReadKey();

public record struct WeatherData(int? Temperature, int? Humidity);

public class WeatherDataAggregator
{
    public IEnumerable<WeatherData> WeatherHistory => _weatherHistory;
    private List<WeatherData> _weatherHistory = new();

    public void GetNotifiedAboutNewData(object? sender, WeatherDataEventArgs weaterDataEvntArgs)
    {
        this._weatherHistory.Add(weaterDataEvntArgs.WeatherData);
    }
}


public class WeatherStation
{
    public event EventHandler<WeatherDataEventArgs>? WeatherMeasured;

    public void Measure()
    {
        int temperature = 25;

        OnWeatherMeasured(temperature);
    }

    private void OnWeatherMeasured(int temperature)
    {
        this.WeatherMeasured?
            .Invoke(this,
                    new WeatherDataEventArgs(
                        new WeatherData(temperature, null)));
    }
}

public class WeatherBaloon
{
    public event EventHandler<WeatherDataEventArgs>? WeatherMeasured;

    public void Measure()
    {
        int humidity = 50;

        OnWeatherMeasured(humidity);
    }

    private void OnWeatherMeasured(int humidity)
    {
        this.WeatherMeasured?
            .Invoke(this,
                    new WeatherDataEventArgs(
                        new WeatherData(null, humidity)));
    }
}

public class WeatherDataEventArgs : EventArgs
{
    public WeatherData WeatherData { get; }

    public WeatherDataEventArgs(WeatherData weatherData)
    {
        WeatherData = weatherData;
    }
}

