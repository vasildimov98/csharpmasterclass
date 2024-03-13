SomeMethod(null!);

void SomeMethod(string message)
{
    Console.WriteLine(message);
}


//public struct Time 
//{
//    public int Hour { get; }
//    public int Minute { get; }

//    public Time(int hour, int minute)
//    {
//        if (hour < 0 || hour > 23)
//        {
//            throw new ArgumentOutOfRangeException(
//                "Hour is out of range of 0-23");
//        }
//        if (minute < 0 || minute > 59)
//        {
//            throw new ArgumentOutOfRangeException(
//                "Minute is out of range of 0-59");
//        }
//        Hour = hour;
//        Minute = minute;
//    }

//    public override string ToString() =>
//        $"{Hour.ToString("00")}:{Minute.ToString("00")}";

//    public override bool Equals(object? obj)
//    {
//        return obj is Time time &&
//               Hour == time.Hour &&
//               Minute == time.Minute;
//    }

//    public override int GetHashCode()
//    {
//        return HashCode.Combine(Hour, Minute);
//    }
//}

//public readonly struct Point : IEquatable<Point>
//{
//    public readonly int X { get; init; }
//    public readonly int Y { get; init; }

//    public Point(int x, int y)
//    {
//        this.X = x;
//        this.Y = y;
//    }

//    public bool Equals(Point other)
//    {
//        return other.X == X && other.Y == Y;
//    }

//    public override bool Equals(object? obj)
//    {
//        return obj is Point p && Equals(p);
//    }

//    public static Point operator +(Point p1, Point p2)
//    {
//        return new Point(p1.X + p1.X, p1.Y + p1.Y);
//    }

//    public static bool operator ==(Point p1, Point p2)
//    {
//        return p1.Equals(p2);
//    }

//    public static bool operator !=(Point p1, Point p2)
//    {
//        return !p1.Equals(p2);
//    }

//    public static implicit operator Point(Tuple<int, int> other)
//    {
//        return new Point { X = other.Item1, Y = other.Item2 };
//    }
//}


//Implement the Time structs according to the following requirements

//using System.Data;

//var validator = new Validator();

//Console.WriteLine(validator.isValid(new SomeClass { Value = 1 }) ? "object is valid" : "object is not valid");
//Console.WriteLine(validator.isValid(new SomeClass { Value = 101 }) ? "object is valid" : "object is not valid");

//Console.ReadKey();

//public class Validator
//{
//    public bool isValid(object obj)
//    {
//        var properties = obj.GetType()
//            .GetProperties()
//            .Where(prop => Attribute.IsDefined(prop, typeof(MustBeLargerThan)));

//        foreach (var prop in properties)
//        {
//            var value = prop.GetValue(obj);

//            if (value is not int)
//            {
//                throw new InvalidOperationException("Attribute must be set only to ints");
//            }

//            var intValue = (int)value;

//            var attribute = (MustBeLargerThan)prop.GetCustomAttributes(typeof(MustBeLargerThan), true).FirstOrDefault();

//            if (attribute.Min > intValue)
//            {
//                return false;
//            }

//        }

//        return true;
//    }
//}

//public class SomeClass
//{
//    [MustBeLargerThan(100)]
//    public int Value { get; init; }
//}

//[AttributeUsage(AttributeTargets.Property)]
//public class MustBeLargerThan : Attribute
//{
//    public MustBeLargerThan(int min)
//    {
//       this.Min = min;
//    }

//    public int Min { get; }
//}

