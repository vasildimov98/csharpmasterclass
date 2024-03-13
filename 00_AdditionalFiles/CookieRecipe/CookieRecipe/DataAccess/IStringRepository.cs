
namespace CookieRecipe.DataAccess
{
    public interface IStringRepository
    {
        public void Add(string filePath, IEnumerable<string> recipesAsStrings);
        IEnumerable<string> GetAll(string filePath);
    }
}
