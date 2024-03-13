using CookieRecipe.Models.Ingredients;
using CookieRecipe.Models.Registers;
using CookieRecipe.Recipes;

namespace CookieRecipe.Books
{
    internal class RecipeConsoleUserInteraction : IRecipeUserInteraction
    {
        private readonly IIngredientsRegister _ingredientsRegister;

        public RecipeConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
        {
            _ingredientsRegister = ingredientsRegister;
        }

        public void Close()
        {
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }

        public IEnumerable<Ingredient> GetIngrediensFromUser()
        {
            var isTimeToExit = false;

            var ingredients = new List<Ingredient>();
            while (!isTimeToExit)
            {
                ShowMessage("Add an ingredient by its ID or type anything else if finished. is printed to the console.");

                var userChoice = Console.ReadLine();

                if (int.TryParse(userChoice, out var id))
                {
                    var ingredient = _ingredientsRegister.GetById(id);

                    if (ingredient is not null)
                    {
                        ingredients.Add(ingredient);
                    }
                }
                else
                {
                    isTimeToExit = true;
                }
            }

            return ingredients;
        }

        public void PromtCreatingNewRecipe()
        {
            this.ShowMessage("Create a new cookie recipe! Available ingredients are:");

            var allIngredients = _ingredientsRegister.GetAll();

            foreach (var ingredient in allIngredients)
            {
                this.ShowMessage(ingredient.ToString());
            }
        }

        public void ShowAllRecipe(IEnumerable<Recipe> allRecipe)
        {
            var count = 1;
            foreach (var recipe in allRecipe)
            {
                this.ShowMessage($"***** {count++} *****");
                this.ShowMessage(recipe.ToString());
                this.ShowMessage(string.Empty);
            }
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
