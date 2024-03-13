using Multithreading_asynchrony_Assignment.Utulities;
using System.Text.RegularExpressions;

internal partial class InputValidator : IValidator
{
    private const string Single_Word_Regex = "^[A-Za-z]+$";

    public bool TryValidadeNumber(string? input, out int result)
    {
        if (int.TryParse(input, out result))
        {
            return true;
        }

        return false;
    }

    public bool Validade(string? word)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return false;
        }

        if (!SingleWord().IsMatch(word))
        {
            return false;
        }

        return true;
    }

    [GeneratedRegex(Single_Word_Regex)]
    private static partial Regex SingleWord();
}
