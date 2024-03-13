using Multithreading_asynchrony_Assignment.DTOs;

internal class QuoteSearcher : IQuoteSearcher
{
    public string? SearchBy(string word, IEnumerable<Quote> quotes)
    {
        var qoute = quotes
                    .Where(quote => IsWordPresentIn(quote.Text, word))
                    .Select(quote => quote.Text)
                    .OrderBy(quote => quote!.Length);

        return qoute.FirstOrDefault();
    }

    private static bool IsWordPresentIn(string? sentence, string word)
    {
        if (sentence == null) { return false; }

        var words = sentence.Split(' ').Select(w => w.ToLower());
        var comparedWordLower = word.ToLower();

        foreach (var currWord in words)
        {
            if (currWord.CompareTo(comparedWordLower) == 0)
            {
                return true;
            }
        }
        return false;
    }
}
