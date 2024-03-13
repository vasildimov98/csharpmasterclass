//Console.WriteLine("Hello, World!");
//Console.WriteLine("[S]ee all TODOs");
//Console.WriteLine("[A]dd a TODO");
//Console.WriteLine("[R]emove a TODO");
//Console.WriteLine("[E]xit");



//var userInput = Console.ReadLine();

//if (userInput == "S")
//{
//    PrintUserSelectedOption("See All Todos");
//}
//else if (userInput == "A")
//{
//    PrintUserSelectedOption("Add a Todos");
//}
//else if (userInput == "R")
//{
//    PrintUserSelectedOption("Remove a Todos");
//}
//else if (userInput == "E")
//{
//    PrintUserSelectedOption("Exit Program");
//}
//else
//{
//    PrintUserSelectedOption("Invalid Choice");
//}

//void PrintUserSelectedOption(string option)
//{
//    Console.WriteLine($"User Selected Option: {option}");
//}

//int a = 49;
//int b = 7;

//Console.WriteLine(a++);
//Console.WriteLine(--b);

// Precedence
//Console.WriteLine("Addition: " + (a + b));
//Console.WriteLine("Substractions: " + (a - b));
//Console.WriteLine("Multiplication: " + a * b);
//Console.WriteLine("Divisition: " + a / b);

//string? userInput = Console.ReadLine();

//Console.WriteLine("User Input: " +  userInput);

//var concat = "abc" + "def" + "ghi";

//Console.WriteLine(concat);

var numbers = new[] { 1, 2, 3, 4, 5, 6, -2, -442, -34 };

var onlyPositeNumbers = GetOnlyPositiveNumbers(numbers, out int nonPositiveNumbers);

foreach (var number in onlyPositeNumbers)
{
    Console.WriteLine(number);
}

Console.WriteLine("Count of non positeve numbers is: " + nonPositiveNumbers);

List<int> GetOnlyPositiveNumbers(int[] numbers, out int nonPositiveNumbers)
{
    nonPositiveNumbers = 0;
    var result = new List<int>();

    foreach (var number in numbers)
    {
        if (number > 0)
        {
            result.Add(number);
        }
        else
        {
            nonPositiveNumbers++;
        }
    }

    return result;
}



Console.ReadKey();
