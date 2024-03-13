using CleanCode_Assignment;

public class PasswordGenerator
{
    private readonly IRandomNumber _random;

    public PasswordGenerator(IRandomNumber random)
    {
        this._random = random;
    }

    public string Generate(
        int minLength, int maxLength, bool useSpecialCharacter)
    {
        Validate(minLength, maxLength);

        int length = GeneratePasswordLength(minLength, maxLength);

        //generate random string
        var chars = useSpecialCharacter ?
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return GenerateRandomPassword(length, chars);
    }
    private static void Validate(int minLength, int maxLength)
    {
        if (1 > minLength)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(minLength)} must be greater than or equal to 1");
        }

        if (minLength > maxLength)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(minLength)} must be smaller than {maxLength}");
        }
    }

    private int GeneratePasswordLength(int minLength, int maxLength)
    {
        return this._random.Next(minLength, maxLength + 1);
    }

    private string GenerateRandomPassword(int length, string characterToBeIncluded)
    {
        var passwordCharacters = Enumerable
                .Repeat(characterToBeIncluded, length)
                .Select(characters =>
                {
                    var index = _random.Next(characters.Length);
                    return characters[index];
                })
                .ToArray();

        return new string(passwordCharacters);
    }

}