var inputValidator = new InputValidator();
var userInteractor = new UserConsoleInteractor(inputValidator);
var quoteGardenApiService = new QuoteGardenApiService();
var quoteSearcher = new QuoteSearcher();

var quoteFinderApp = new QuoteFinderApp(userInteractor, quoteGardenApiService, quoteSearcher);

try
{
    await quoteFinderApp.Run();
}
catch (Exception ex)
{
	userInteractor.ShowMessage("App crashed unexpectedly with message: " + ex.Message);
}
finally
{
    userInteractor.ShowMessage("Program is finished.");
}

Console.ReadKey();
