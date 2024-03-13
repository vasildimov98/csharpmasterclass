using FibonacciGenerator;

Console.WriteLine(string.Join(",", Fibonacci.Generate(2)));
Console.WriteLine(string.Join(",", Fibonacci.Generate(4)));
Console.WriteLine(string.Join(",", Fibonacci.Generate(6)));
Console.WriteLine(string.Join(",", Fibonacci.Generate(8)));
Console.WriteLine(string.Join(",", Fibonacci.Generate(10)));

Console.ReadKey();