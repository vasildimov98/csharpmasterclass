
namespace CookieRecipe.DataAccess
{
    public abstract class StringRepository : IStringRepository
    {
        public void Add(string filePath, IEnumerable<string> recipesAsStrings)
        {
            File.WriteAllText(filePath, this.StringsToText(recipesAsStrings));
        }

        public IEnumerable<string> GetAll(string filePath)
        {
            if (!File.Exists(filePath)) 
            {
                return new List<string>();
            }

            var fileContent = File.ReadAllText(filePath);

            return this.FormTextToObject(fileContent);
        }

        protected abstract string StringsToText(IEnumerable<string> strings);

        protected abstract List<string> FormTextToObject(string content);

    }
}
