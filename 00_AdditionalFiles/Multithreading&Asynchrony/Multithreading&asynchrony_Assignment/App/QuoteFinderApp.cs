using Multithreading_asynchrony_Assignment.ApiService;

internal class QuoteFinderApp(IUserInteractor userInteractor, IApiService apiService, IQuoteSearcher quoteSearcher)
{
    private readonly IUserInteractor _userInteractor = userInteractor;
    private readonly IApiService _apiService = apiService;
    private readonly IQuoteSearcher _quoteSearcher = quoteSearcher;

    internal async Task Run()
    {
        var wordToSearch = this._userInteractor
            .PrompUserToSelectWord("Select a word:");
        this._userInteractor.ShowMessage(string.Empty);

        var numberOfPages = this._userInteractor
            .PrompUserToSelectNumberOf("Select number of pages:");
        this._userInteractor.ShowMessage(string.Empty);

        var numberOfQuotes = this._userInteractor
            .PrompUserToSelectNumberOf("Select number of quotes:");
        this._userInteractor.ShowMessage(string.Empty);
        //TODO: (optional) Whether the processing of the downloaded
        //data should be performed in parallel or not.

        for (int page = 1; page <= numberOfPages; page++)
        {
            var quotes = await this._apiService.GetPageAsync(numberOfQuotes, page);

            if (wordToSearch is  null)
            {
                throw new ArgumentNullException(nameof(wordToSearch));
            }

            var foundQuote = this._quoteSearcher.SearchBy(wordToSearch, quotes);

            if (string.IsNullOrWhiteSpace(foundQuote))
            {
                this._userInteractor
                    .ShowMessage($"There is no quote that contains the word {wordToSearch} at page: {page}");
                this._userInteractor.ShowMessage(string.Empty);

                continue;
            }

            this._userInteractor
                .ShowMessage($"Found a quote that contains the word {wordToSearch} at page: {page}");
            this._userInteractor.ShowMessage(string.Empty);

            this._userInteractor.ShowMessage($"The Quote: {foundQuote}");

            this._userInteractor.ShowMessage(string.Empty);
        }
    }
}
