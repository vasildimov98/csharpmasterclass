using CookieRecipe.Recipes;

namespace CookieRecipe.Books
{
    public class CookieRecipeBook
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeUserInteraction _recipeUserInteraction;

        public CookieRecipeBook(IRecipeRepository recipeRepository, IRecipeUserInteraction recipeUserInteraction)
        {
            this._recipeRepository = recipeRepository;
            this._recipeUserInteraction = recipeUserInteraction;
        }

        public void Open(string filePath)
        {
            var allRecipe = this._recipeRepository.GetAll(filePath) as List<Recipe>;

            if (allRecipe is not null)
            {
                this._recipeUserInteraction.ShowAllRecipe(allRecipe);
            }

            this._recipeUserInteraction.PromtCreatingNewRecipe();

            var ingrediens = this._recipeUserInteraction.GetIngrediensFromUser();

            if (ingrediens.Count() > 0)
            {
                var recipe = new Recipe(ingrediens);
                allRecipe.Add(recipe);
                this._recipeRepository.Add(filePath, allRecipe);
                this._recipeUserInteraction.ShowMessage("Recipe Added:");
                this._recipeUserInteraction.ShowMessage(recipe.ToString());
            }
            else
            {
                this._recipeUserInteraction.ShowMessage("No ingredients have been selected. Recipe will not be saved.” is printed.");
            }

            this._recipeUserInteraction.Close();
        }
    }
}
