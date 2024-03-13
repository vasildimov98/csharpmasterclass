using System.Collections;

var myLinkedList = new MyLinkedList<string>
{
    "1",
    "2",
    "3",
};

Console.WriteLine($"The Count is: {myLinkedList.Count}");

myLinkedList.AddToEnd("4");
myLinkedList.AddToFront("0");
myLinkedList.AddToEnd("5");
myLinkedList.Add("123");

Console.WriteLine($"The Count is: {myLinkedList.Count}");

var isRemoved = myLinkedList.Remove("123");
Console.WriteLine($"123 was removed: {isRemoved}");

Console.WriteLine($"The Count is: {myLinkedList.Count}");

var isRemoved2 = myLinkedList.Remove("0");
Console.WriteLine($"First element was removed: {isRemoved2}");

Console.WriteLine($"The Count is: {myLinkedList.Count}");

var isRemoved3 = myLinkedList.Remove("322");
Console.WriteLine($"322 was removed: {isRemoved3}");

Console.WriteLine($"The Count is: {myLinkedList.Count}");

Console.WriteLine($"The number 5 is present is the linked list: {myLinkedList.Contains("5")}");
Console.WriteLine($"The number 1 is present is the linked list: {myLinkedList.Contains("1")}");
Console.WriteLine($"The number 23 is present is the linked list: {myLinkedList.Contains("23")}");

var arr = new string[10];
myLinkedList.CopyTo(arr, 0);
myLinkedList.CopyTo(arr, 4);
myLinkedList.CopyTo(arr, 2);
myLinkedList.CopyTo(arr, 3);

try
{
    myLinkedList.CopyTo(arr, 5);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

foreach (var item in myLinkedList)
{
    Console.WriteLine(item);
}

myLinkedList.Clear();

Console.ReadKey();

public class Node<T>(T value)
{
    public T Value { get; } = value;

    public Node<T>? Next { get; set; }
}

public class MyLinkedList<T> : ILinkedList<T>
{
    private Node<T>? _head;
    private int _count = 0;
    private readonly bool _isReadOnly = false;

    public int Count => this._count;

    public bool IsReadOnly => this._isReadOnly;

    public void Add(T item)
    {
        this.AddToEnd(item);
    }

    public void AddToFront(T item)
    {
        var node = new Node<T>(item);

        if (this.Count == 0)
        {
            this._head = node;
        }
        else
        {
            var currentHead = this._head;
            this._head = node;
            this._head.Next = currentHead;
        }

        this._count++;
    }

    public void AddToEnd(T item)
    {
        var node = new Node<T>(item);
        if (this.Count == 0)
        {
            this._head = node;
            this._count++;
            return;
        }

        var currNode = this._head;
        while (currNode!.Next is not null)
        {
            currNode = currNode.Next;
        }

        currNode.Next = node;
        this._count++;
    }

    public bool Remove(T item)
    {
        if (this._head is null) return false;

        if (this._head.Value!.Equals(item))
        {
            this._head = this._head.Next;
            this._count--;
            return true;
        }

        var currEl = this._head.Next;
        var prev = currEl;

        while (currEl is not null)
        {
            if (currEl.Next is null)
            {
                prev!.Next = currEl.Next;
                this._count--;
                return true;
            }

            prev = currEl;
            if (currEl.Value!.Equals(item))
            {
                prev!.Next = currEl.Next;
                currEl.Next = null;
                this._count--;
                return true;
            }

            currEl = currEl.Next;
        }

        return false;
    }

    public void Clear()
    {
        var currEl = this._head;
        while (currEl is not null)
        {
            var temp = currEl;
            currEl = currEl.Next;
            temp.Next = null;
        }

        this._count = 0;
        this._head = null;
    }

    public bool Contains(T item)
    {
        var currNode = this._head;

        if (currNode is null) return false; 

        while(currNode is not null)
        {
            if (currNode.Value!.Equals(item)) return true;

            currNode = currNode.Next;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {

        ArgumentNullException.ThrowIfNull(array);

        if (this.Count >= array.Length - arrayIndex) throw new ArgumentException(nameof(array) + " is not long enough");

        if (arrayIndex < 0 || arrayIndex >= array.Length)
            throw new IndexOutOfRangeException($"Index: {arrayIndex} was out of range");

        var currEl = this._head;
        var currIndex = arrayIndex;
        while(currEl is not null)
        {
            array[currIndex++] = currEl.Value;
            currEl = currEl.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currEl = this._head;

        while(currEl is not null)
        {
            yield return currEl.Value;
            currEl = currEl.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnd(T item);
}
