using CookieRecipe.Models.Ingredients;
using CookieRecipe.Recipes;

namespace CookieRecipe.Books
{
    public interface IRecipeUserInteraction
    {
        IEnumerable<Ingredient> GetIngrediensFromUser();

        void PromtCreatingNewRecipe();

        void ShowAllRecipe(IEnumerable<Recipe> allRecipe);

        void ShowMessage(string message);

        void Close();
    }
}
