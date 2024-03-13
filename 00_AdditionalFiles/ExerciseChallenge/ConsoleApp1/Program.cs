using System.Diagnostics.Tracing;
using System.Globalization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static int Transform(
           int number)
        {
            var transformations = new List<INumericTransformation>
            {
                new By1Incrementer(),
                new By2Multiplier(),
                new ToPowerOf2Raiser()
            };

            var result = number;
            foreach (var transformation in transformations)
            {
                result = transformation.Transform(result);
            }
            return result;
        }

        
    }

    
}
