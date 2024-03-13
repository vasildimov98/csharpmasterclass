using Multithreading_asynchrony_Assignment.Utulities;

public class UserConsoleInteractor(IValidator validator) : IUserInteractor
{
    private readonly IValidator _validator = validator;

    public string? PrompUserToSelectWord(string message)
    {
        ShowMessage(message);

        var word = Console.ReadLine();

        while(!this._validator.Validade(word))
        {
            this.ShowMessage("Invalid input!" +
                " Provided input should be a single word, without spaces," +
                " numbers or special characters");

            word = Console.ReadLine();
        }

        return word;
    }

    public int PrompUserToSelectNumberOf(string message)
    {
        ShowMessage(message);

        var input = Console.ReadLine();
        int result;
        while (!this._validator.TryValidadeNumber(input, out result))
        {
            this.ShowMessage("Invalid input!" +
                " Provided input should be a whole number");

            input = Console.ReadLine();
        }

        return result;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
