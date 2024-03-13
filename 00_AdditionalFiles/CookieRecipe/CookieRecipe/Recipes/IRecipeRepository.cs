namespace CookieRecipe.Recipes
{
    public interface IRecipeRepository
    {
        void Add(string filePath, List<Recipe> allRecipe);

        IEnumerable<Recipe> GetAll(string filePath);
    }
}
