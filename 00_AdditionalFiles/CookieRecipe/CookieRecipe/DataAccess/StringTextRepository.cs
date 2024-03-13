
namespace CookieRecipe.DataAccess
{
    public class StringTextRepository : StringRepository
    {
        private static readonly string Separator = Environment.NewLine;

        protected override List<string> FormTextToObject(string content)
        {
            return content.Split(Separator).ToList();
        }

        protected override string StringsToText(IEnumerable<string> strings)
        {
            return string.Join(Separator, strings);
        }
    }
}
