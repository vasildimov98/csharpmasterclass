public static class StackExtensions
{
    public static IEnumerable<T> GetAllAfterLastNullReversed<T>(IList<T> input)
    {
        
    }
}


//var sortedList = new List<int>
//{
//    2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30
//};

//Console.WriteLine(sortedList.FindIndexBinary(2));
//Console.WriteLine(sortedList.FindIndexBinary(6));
//Console.WriteLine(sortedList.FindIndexBinary(16));
//Console.WriteLine(sortedList.FindIndexBinary(20));
//Console.WriteLine(sortedList.FindIndexBinary(30));
//Console.WriteLine(sortedList.FindIndexBinary(13));

//Console.ReadKey();

//public static class ListExtions
//{
//    public static int? FindIndexBinary<T>(this IList<T> list, T number) where T : IComparable<T>
//    {
//        var leftIndex = 0;
//        var rightIndex = list.Count - 1;

//        while(leftIndex <= rightIndex)
//        {
//            var middleIndex = (leftIndex + rightIndex) / 2;

//            if (list[middleIndex].Equals(number))
//            {
//                return middleIndex;
//            }
//            else if (list[middleIndex].CompareTo(number) > 0)
//            {
//                rightIndex = middleIndex - 1;
//            } 
//            else
//            {
//                leftIndex = middleIndex + 1;
//            }
//        }

//        return null;
//    }
//}

//using System.Collections;

//var wordsCollection = new WordsCollection
//{
//    "Hello", "World.", "My", "Name", "is", "Slim", "Shady!"
//};

//var nameWord = wordsCollection[3];
//Console.WriteLine(nameWord);
//wordsCollection[3] = "name";

//Console.WriteLine("The default implementation: ");
//foreach (var word in wordsCollection)
//{
//    Console.WriteLine(word);
//}

//Console.ReadKey();

//public class WordsCollection : IEnumerable<string>
//{
//    private int currentIndex = 0;
//    private readonly string[] _words;

//    public WordsCollection(int defaultIndex = 10)
//    {
//        this._words = new string[defaultIndex];
//    }

//    public WordsCollection(string[] words)
//    {
//        this._words = words;
//    }

//    public string this[int index]
//    {
//        get => this._words[index];
//        set => this._words[index] = value;
//    }

//    public void Add(string word)
//    {
//        this._words[this.currentIndex++] = word;
//    }

//    IEnumerator IEnumerable.GetEnumerator()
//    {
//        return this.GetEnumerator();
//    }

//    public IEnumerator<string> GetEnumerator()
//    {
//        return new WordsEnumerator(this._words);
//    }
//}

//public class WordsEnumerator :  IEnumerator<string>
//{
//    private const int INITIAL_VALUE = -1;
//    private int _index = INITIAL_VALUE;
//    private readonly string[] _words;

//    public WordsEnumerator(string[] words)
//    {
//        this._words = words;
//    }

//    public string Current
//    {
//        get
//        {
//            try
//            {
//                return this._words[this._index];
//            }
//            catch (IndexOutOfRangeException ex)
//            {
//                throw new IndexOutOfRangeException($"The index: {this._index} was out of range", ex);
//            }
//        }
//    }

//    object IEnumerator.Current => this.Current;

//    public bool MoveNext()
//    {
//        return ++this._index < this._words.Length;
//    }

//    public void Reset()
//    {
//        this._index = INITIAL_VALUE;
//    }

//    public void Dispose()
//    {
//    }
//}


//public class PairOfArrays<TLeft, TRight>
//{
//    private readonly TLeft[] _left;
//    private readonly TRight[] _right;

//    public PairOfArrays(
//        TLeft[] left, TRight[] right)
//    {
//        _left = left;
//        _right = right;
//    }

//    public (TLeft item1, TRight item2) this[int leftIndex, int rightIndex]
//    {
//        get => (this._left[leftIndex], this._right[rightIndex]);
//        set
//        {
//            this._left[leftIndex] = value.Item1;
//            this._right[rightIndex] = value.Item2;
//        }
//    }
//}