
using System.Text.Json;

namespace CookieRecipe.DataAccess
{
    internal class StringJsonRepository : StringRepository
    {
        protected override List<string> FormTextToObject(string content)
        {
            return JsonSerializer.Deserialize<List<string>>(content);
        }

        protected override string StringsToText(IEnumerable<string> strings)
        {
            return JsonSerializer.Serialize(strings);
        }
    }
}
