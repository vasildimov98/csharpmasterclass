var list = new MyList<int>();

list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Add(5);
list.Add(6);
list.Add(7);
list.Add(8);
list.Add(9);

list.RemoveAt(4);

Console.WriteLine(list.GetAtIndex(4));

Console.ReadKey();

class MyList<T>
{
    private T[] _items = new T[4];

    private int _size = 0;

    public void Add(T item)
    {
        if (this._size == this._items.Length)
        {
            var currItem = new T[this._size * 2];

            for (int i = 0; i < this._size; i++)
            {
                currItem[i] = this._items[i];
            }

            _items = currItem;
        }

        this._items[this._size++] = item;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this._items.Length)
        {
            throw new IndexOutOfRangeException($"Index '{index}' is outside of the bounds of the array");
        }

        --this._size;

        for (int i = index; i < this._size; i++)
        {
            this._items[i] = this._items[i + 1];
        }

        _items[this._size] = default;
    }

    public T GetAtIndex(int index)
    {
        if (index < 0 || index >= this._items.Length)
        {
            throw new IndexOutOfRangeException($"Index '{index}' is outside of the bounds of the array");
        }

        return this._items[index];
    }
}
