namespace CookieRecipe.Enums
{
    public static class FileFormatExtion
    {
        public static string GetExtention(this FileFormat format)
        {
            switch (format)
            {
                case FileFormat.Text:
                    return "txt";
                case FileFormat.JSON:
                    return "json";
                default: return "txt";
            }
        }
    }
}
