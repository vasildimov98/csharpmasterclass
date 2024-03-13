public static class StringExtentions
{
    public static string ExtractDomain(this string site)
    {
        var indexOf = site.LastIndexOf('.');

        return site.Substring(indexOf);
    }
}