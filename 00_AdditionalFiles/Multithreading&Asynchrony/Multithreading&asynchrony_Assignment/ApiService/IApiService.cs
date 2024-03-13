namespace Multithreading_asynchrony_Assignment.ApiService;

internal interface IApiService
{
    Task<IEnumerable<Quote>> GetPageAsync(int limit, int page);
}