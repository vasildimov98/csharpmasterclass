namespace CookieRecipe.Models.Ingredients
{
    internal class Cardamom : Ingredient
    {
        public override int Id => 6;

        public override string Name => "Cardamom";

        public override string PreparationInstructions => $"Take half a teaspoon. {base.PreparationInstructions}";
    }
}
