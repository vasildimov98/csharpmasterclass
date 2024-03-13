
using CookieRecipe.Books;
using CookieRecipe.DataAccess;
using CookieRecipe.Enums;
using CookieRecipe.Models.Registers;
using CookieRecipe.Recipes;

namespace CookieRecipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //const FileFormat FileFormat = FileFormat.Text;

            //var fileData = new FileMetadata("recipes", FileFormat);
            //var filePath = fileData.FilePath;
            //IStringRepository stringRepository = FileFormat.Text == FileFormat ? new StringTextRepository() : new StringJsonRepository();
            //IIngredientsRegister ingredientRegister = new IngredientsRegister();

            //var recipeFileRepository = new RecipeFileRepository(stringRepository, ingredientRegister);
            //var recipeConsoleUserInteraction = new RecipeConsoleUserInteraction(ingredientRegister);
            //var cookieRecipeBook = new CookieRecipeBook(recipeFileRepository, recipeConsoleUserInteraction);

            //cookieRecipeBook.Open(filePath);

            DivideNumbers(1, 0);
            Console.ReadKey();
        }

        public static int DivideNumbers(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception)
            {
                Console.WriteLine("Division by zero.");
                return 0;
            }
            finally
            {
                Console.WriteLine("The DivideNumbers method ends.");
            }
        }
    }
}
