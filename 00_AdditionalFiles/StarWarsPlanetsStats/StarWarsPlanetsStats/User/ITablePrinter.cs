public interface ITablePrinter
{
    void Print<T>(IEnumerable<T> collection);

    void PrintLine();
    void PrintRow(string[] strings);
}
