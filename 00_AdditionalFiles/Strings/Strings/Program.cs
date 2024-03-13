using System.Diagnostics;
using System.Text;

var text = "";

var loop = 2_000_000_000;

var stopWatch = Stopwatch.StartNew();
var sb = new StringBuilder();
for (var i = 0; i < loop; i++)
{
    sb.Append('a');
}

sb.ToString();
stopWatch.Stop();

Console.WriteLine($"String Building took: {stopWatch.ElapsedMilliseconds} ms");


Console.ReadKey();