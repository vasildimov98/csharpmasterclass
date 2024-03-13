using CookieRecipe.DataAccess;
using CookieRecipe.Models.Ingredients;
using CookieRecipe.Models.Registers;

namespace CookieRecipe.Recipes
{
    public class RecipeFileRepository : IRecipeRepository
    {
        private const string Seperator = ",";

        private IStringRepository _stringRepository;
        private IIngredientsRegister _ingredientsRegister;

        public RecipeFileRepository(IStringRepository stringRepository, IIngredientsRegister ingredientsRegister)
        {
            _stringRepository = stringRepository;
            _ingredientsRegister = ingredientsRegister;
        }

        public void Add(string filePath, List<Recipe> allRecipe)
        {
            var recipesAsStrings = new List<string>();

            foreach (var recipe in allRecipe)
            {
                var ids = new List<int>();
                foreach (var ingredients in recipe.Ingredients)
                {
                    ids.Add(ingredients.Id);
                }

                recipesAsStrings.Add(string.Join(Seperator, ids));
            }

            _stringRepository.Add(filePath, recipesAsStrings);
        }

        public IEnumerable<Recipe> GetAll(string filePath)
        {
            var allRecipesFromFile = this._stringRepository.GetAll(filePath) as List<string>;

            var result = new List<Recipe>();

            foreach(var recipeFromFile in allRecipesFromFile)
            {
                var recipe = this.CreateRecipeFromString(recipeFromFile);
                result.Add(recipe);
            }

            return result;
        }

        private Recipe CreateRecipeFromString(string recipeFromFile)
        {
            var ingredietsIds = recipeFromFile.Split(Seperator);
            var ingredients = new List<Ingredient>();

            foreach (var ingredientId in ingredietsIds)
            {
                var id = int.Parse(ingredientId);
                var ingredient = this._ingredientsRegister.GetById(id);
                ingredients.Add(ingredient);
            }

            return new Recipe(ingredients);
        }
    }
}
