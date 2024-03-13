namespace CleanCode_Assignment;

public interface IRandomNumber
{
    int Next(int minValue, int maxValue);

    int Next(int maxValue);
}