namespace CookieRecipe.Models.Ingredients
{
    internal class Cinnamon : Ingredient
    {
        public override int Id => 7;

        public override string Name => "Cinnamon";

        public override string PreparationInstructions => $"Take half a teaspoon. {base.PreparationInstructions}";
    }

}
