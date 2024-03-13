namespace DiceGame.Validators
{
    internal static class ChoiceValidator
    {
        public static bool IsValid(string? choice)
        {
            if (string.IsNullOrEmpty(choice)) return false;
            return int.TryParse(choice, out _); ;
        }
    }
}