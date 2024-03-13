using CookieRecipe.Models.Ingredients;

namespace CookieRecipe.Models.Registers
{
    public class IngredientsRegister : IIngredientsRegister
    {
        public IngredientsRegister()
        {
            this.All = new List<Ingredient>
            {
                new WheatFlour(),
                new CoconutFlour(),
                new Butter(),
                new Chocolate(),
                new Sugar(),
                new Cardamom(),
                new Cinnamon(),
                new Cocoa(),
            };
        }

        public IEnumerable<Ingredient> All { get; }

        public IEnumerable<object> GetAll()
        {
            return this.All;
        }

        public Ingredient GetById(int id)
        {
            foreach (var item in this.All)
            {
                if (item.Id == id) return item;
            }

            return null;
        }
    }
}
