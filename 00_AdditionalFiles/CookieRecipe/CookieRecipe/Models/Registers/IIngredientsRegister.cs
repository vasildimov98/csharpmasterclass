using CookieRecipe.Models.Ingredients;

namespace CookieRecipe.Models.Registers
{
    public  interface IIngredientsRegister
    {
        IEnumerable<object> GetAll();
        Ingredient GetById(int id);
    }
}
