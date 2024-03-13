using Multithreading_asynchrony_Assignment.DTOs;

internal interface IQuoteSearcher
{
    string? SearchBy(string word, IEnumerable<Quote> quotes);
}
