namespace Coding.Exercise
{
    public class Exercise
    {
        public static IEnumerable<DateTime> GetFridaysOfYear(int year, IEnumerable<DateTime> dates)
        {
            return dates.Where(d => d.Year == year && d.DayOfWeek == DayOfWeek.Friday).Distinct();
        }
    }
}
