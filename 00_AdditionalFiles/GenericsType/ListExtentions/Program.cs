// Dictionalry


public static class Exercise
{
    public static Dictionary<PetType, double> FindMaxWeights(List<Pet> pets)
    {
        var dic = new Dictionary<PetType, double>();

        foreach (var pet in pets)
        {
            if (!dic.ContainsKey(pet.PetType))
            {
                dic[pet.PetType] = pet.Weight;
            }

            if (dic[pet.PetType] < pet.Weight)
            {
                dic[pet.PetType] = pet.Weight;
            }
        }

        return dic;
    }
}

public class Pet
{
    public PetType PetType { get; }
    public double Weight { get; }

    public Pet(PetType petType, double weight)
    {
        PetType = petType;
        Weight = weight;
    }

    public override string ToString() => $"{PetType}, {Weight} kilos";
}

public enum PetType { Dog, Cat, Fish }

//// Advanced Method
//static void TestMethod()
//{
//    /*your code goes here*/
//    Func<int, bool, double> someMethod1 = Method1;
//    /*your code goes here*/
//    Func<DateTime> someMethod2 = Method2;
//    /*your code goes here*/
//    Action<string, string> someMethod3 = Method3;
//}

//static double Method1(int a, bool b) => 0;
//static DateTime Method2() => default(DateTime);
//static void Method3(string a, string b) { }

// IComparable;

//var sortedList = new SortedList<FullName>(
//        new List<FullName> { 
//            new FullName { FirstName = "John", LastName = "Smith" },
//            new FullName { FirstName = "Anna", LastName = "Smith" },
//            new FullName { FirstName = "Kenji", LastName = "Narasaki" },
//            new FullName { FirstName = "John ", LastName = "Watson" } });


//Console.ReadKey();

//public class SortedList<T> where T : IComparable<T>
//{
//    public IEnumerable<T> Items { get; }

//    public SortedList(IEnumerable<T> items)
//    {
//        var asList = items.ToList();
//        asList.Sort();
//        Items = asList;
//    }
//}

//public class FullName : IComparable<FullName>
//{
//    public string FirstName { get; init; }
//    public string LastName { get; init; }

//    public override string ToString() => $"{FirstName} {LastName}";

//    public int CompareTo(FullName other)
//    {
//        var comparableValueLastName = this.LastName.CompareTo(other.LastName);
//        var comparableValueFirstName = this.FirstName.CompareTo(other.FirstName);

//        if (comparableValueLastName == 0 || comparableValueLastName > 0)
//        {
//            return comparableValueFirstName;
//        }

//            return -1;
//    }
//}


// Random Elements

//using System.Diagnostics;

//var stopWatch = Stopwatch.StartNew();

//var randomInt = CreateCollectionOfRandomLength<DateTime>();

//stopWatch.Stop();

//Console.WriteLine($"It tool {stopWatch.ElapsedMilliseconds} ms to execute");

//Console.ReadKey();

//IEnumerable<T> CreateCollectionOfRandomLength<T>(int maxLength = 10000000) where T : new()
//{
//    var length = maxLength; /*new Random().Next(maxLength + 1)*/

//    var list = new List<T>(length);

//    for (int i = 0; i < length; i++)
//    {
//        list.Add(new T());
//    }

//    return list;
//}


//var list = new List<decimal>() { 1.23421m, 2.2321m, 3.461m, 4.323m };

//var intList = list.ConvertToInt<decimal, int>();

//for (int i = 0; i < intList.Count; i++)
//{
//    Console.WriteLine(intList[i]);  
//}


//Console.ReadKey();

//public static class ListExtentions
//{
//    public static List<TTarget> ConvertToInt<TSource, TTarget>(this List<TSource> items)
//    {
//        var list = new List<TTarget>();

//        foreach (var item in items)
//        {
//            var convertedEl = (TTarget)Convert.ChangeType(item, typeof(TTarget));
//            list.Add(convertedEl);
//        }

//        return list;
//    }


//}
