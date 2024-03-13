using CookieRecipe.Models.Ingredients;

namespace CookieRecipe.Recipes
{
    public class Recipe
    {
        public Recipe(IEnumerable<Ingredient> ingrediens)
        {
            Ingredients = ingrediens;
        }

        public IEnumerable<Ingredient> Ingredients { get; }

        public override string ToString()
        {
            var result = new List<string>();

            foreach (var ingredient in Ingredients)
            {
                result.Add($"{ingredient.Name}. {ingredient.PreparationInstructions}");
            }

            return string.Join(Environment.NewLine, result);
        }
    }
}
