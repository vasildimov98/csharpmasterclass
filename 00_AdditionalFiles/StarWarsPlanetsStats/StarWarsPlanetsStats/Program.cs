using StarWarsPlanetsStats.App;
using StarWarsPlanetsStats.DataAccess;
using StarWarsPlanetsStats.DataReader;
using StarWarsPlanetsStats.User;

//using var httpClinet = new HttpClient();
//var starWars = new StarWarsApi(httpClinet);
//var planetsReader = new PlanetFromApiReader(starWars);
//var tablePrinter = new TableConsolePrinter();
//var userInteraction = new UserConsoleInteraction(tablePrinter);
//var starWarsPlanetReader = new StarWarsPlanetAnalyzer(userInteraction);

//var starWarsPlanetEngine = new StarWarsPlanetEngine(planetsReader, starWarsPlanetReader, userInteraction);

//try
//{
//    await starWarsPlanetEngine.Start();
//}
//catch (Exception ex)
//{
//    userInteraction.ShowMessage("App unexpectedly crash. Message shown: " + ex.Message);
//    userInteraction.Exit();
//}


var person1 = new Person("John", 24);
var person2 = new Person("John", 24);

Console.WriteLine($"Reference Evaluation: {person1 == person2}");
Console.WriteLine($"Value Evaluation: {person1.Equals(person2)}");

Console.ReadKey();

public record struct Person(string Name, int Age);
