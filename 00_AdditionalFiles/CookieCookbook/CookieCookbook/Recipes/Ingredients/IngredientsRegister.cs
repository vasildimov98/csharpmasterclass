namespace CookieCookbook.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id) => this.All.Where(i => i.Id == id).FirstOrDefault();
}

