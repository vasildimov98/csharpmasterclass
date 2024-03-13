namespace Multithreading_asynchrony_Assignment.Utulities;

public interface IValidator
{
    bool TryValidadeNumber(string? input, out int result);
    bool Validade(string? word);
}