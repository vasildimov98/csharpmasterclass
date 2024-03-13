using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;
using OldSolution;
using System.Net.Http.Headers;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<FastRow>();

        foreach (var row in csvData.Rows)
        {
            var newRowData = new Dictionary<string, object>();
            var fastRow = new FastRow();
            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = row[columnIndex];

                if (string.IsNullOrEmpty(valueAsString))
                {
                    continue;
                }
                else if (valueAsString == "TRUE")
                {
                    fastRow.AssignCell(true, column);
                }
                else if (valueAsString == "FALSE")
                {
                    fastRow.AssignCell(false, column);
                }
                else if (valueAsString.Contains(".") && decimal.TryParse(valueAsString, out var valueAsDecimal))
                {
                    fastRow.AssignCell(valueAsDecimal, column);
                }
                else if (int.TryParse(valueAsString, out var valueAsInt))
                {
                    fastRow.AssignCell(valueAsInt, column);
                }
                else fastRow.AssignCell(valueAsString, column);
            }

            resultRows.Add(fastRow);
        }

        return new FastTableData(csvData.Columns, resultRows);
    }
}

public class FastTableData : ITableData
{
    private readonly List<FastRow> _rows;
    public int RowCount => _rows.Count;
    public IEnumerable<string> Columns { get; }

    public FastTableData(IEnumerable<string> columns, List<FastRow> rows)
    {
        _rows = rows;
        Columns = columns;
    }

    public object GetValue(string columnName, int rowIndex)
    {
        return _rows[rowIndex].GetAtColumn(columnName);
    }
}

public class FastRow
{
    private Dictionary<string, int> _dataInt32 = new();
    private Dictionary<string, decimal> _dataDecimal = new();
    private Dictionary<string, bool> _dataBool = new();
    private Dictionary<string, string> _dataString = new();

    public void AssignCell(int value, string columnName)
    {
        _dataInt32[columnName] =  value;
    }

    public void AssignCell(decimal value, string columnName)
    {
        _dataDecimal[columnName] = value;
    }

    public void AssignCell(bool value, string columnName)
    {
        _dataBool[columnName] = value;
    }

    public void AssignCell(string value, string columnName)
    {
        _dataString[columnName] = value;
    }

    public object GetAtColumn(string columnName)
    {
        if (_dataInt32.ContainsKey(columnName)) return (_dataInt32[columnName]);
        if (_dataDecimal.ContainsKey(columnName)) return (_dataDecimal[columnName]);
        if (_dataBool.ContainsKey(columnName)) return (_dataBool[columnName]);
        if (_dataString.ContainsKey(columnName)) return (_dataString[columnName]);
        return null;
    }
}