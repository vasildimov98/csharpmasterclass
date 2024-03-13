using CookieCookbook.DataAccess;
using CookieCookbook.Recipes.Ingredients;

namespace CookieCookbook.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipesRepository(
        IStringsRepository stringsRepository,
        IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        return this._stringsRepository.Read(filePath).Select(RecipeFromString).ToList();
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        return new Recipe(recipeFromFile
                            .Split(Separator)
                            .Select(id =>
                                this._ingredientsRegister
                                    .GetById(int
                                        .Parse(id))));
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        //var recipesAsStrings = new List<string>();
        //foreach (var recipe in allRecipes)
        //{
        //    var allIds = new List<int>();
        //    foreach (var ingredient in recipe.Ingredients)
        //    {
        //        allIds.Add(ingredient.Id);
        //    }
        //    recipesAsStrings.Add(string.Join(Separator, allIds));
        //}

        _stringsRepository
                .Write(filePath,
                    allRecipes
                        .Select(recipe => 
                            string.Join(Separator,
                                recipe.Ingredients
                                    .Select(ingredient=> ingredient.Id)))
                        .ToList());
    }
}
