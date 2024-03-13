namespace StarWarsPlanetsStats.User
{
    public class TableConsolePrinter : ITablePrinter
    {
        private const int TABLE_WIDTH = 73;

        public void Print<T>(IEnumerable<T> table)
        {
            var prop = typeof(T).GetProperties();

            PrintLine();
            PrintRow(prop.Select(p => p.Name).ToArray());
            PrintLine();

            foreach (var plan in table)
            {
                if (plan is not null)
                {
                    var values = prop.Select(p =>
                    {
                        var value = p.GetValue(plan);

                        if (value != null)
                        {
                            return value.ToString();
                        }

                        return string.Empty;
                    }).ToArray();
                    this.PrintRow(values);
                }
            }

            PrintLine();
        }

        public void PrintLine()
        {
            Console.WriteLine(new string('-', TABLE_WIDTH));
        }

        public void PrintRow(params string?[] columns)
        {
            int width = (TABLE_WIDTH - columns.Length) / columns.Length;

            string row = "|";

            foreach (string? column in columns)
            {
                if (column is null) { continue; }

                if (column == "unknown")
                {
                    row += AlignCentre(string.Empty, width) + "|";
                }
                else
                {
                    row += AlignCentre(column, width) + "|";
                }
            }

            Console.WriteLine(row);
        }

        private static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? string.Concat(text.AsSpan(0, width - 3), "...") : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}