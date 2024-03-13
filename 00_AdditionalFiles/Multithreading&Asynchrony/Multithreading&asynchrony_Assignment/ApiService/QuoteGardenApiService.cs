using Multithreading_asynchrony_Assignment.ApiService;
using Multithreading_asynchrony_Assignment.DTOs;
using System.Text.Json;

internal class QuoteGardenApiService : IApiService
{

    public async Task<IEnumerable<Quote>> GetPageAsync(int limit, int page)
    {
        using var httpClinet = new HttpClient();

        var url = $"https://quote-garden.onrender.com/api/v3/quotes?limit={limit}&page={page}";

        var response = await httpClinet.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var data = JsonSerializer.Deserialize<Root>(json)?.data;

        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        } 

        var result = this.ConvertData(data);

        return result;
    }

    private IEnumerable<Quote> ConvertData(IEnumerable<Datum> data)
    {
        return data.Select(data => new Quote { Text = data.quoteText });
    }
}
