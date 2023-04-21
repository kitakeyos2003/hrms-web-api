namespace WebApi.Models.Helper
{
    public class DateTimeHelper
    {
        public static int CountSundays(DateTime start, DateTime end)
        {
            int sundayCount = 0;
            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    sundayCount++;
                }
            }
            return sundayCount;
        }

        public static int DaysBetween(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            return timeSpan.Days;
        }
    }
}
