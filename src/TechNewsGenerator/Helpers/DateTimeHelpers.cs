namespace TechNewsGenerator.Helpers;

public static class DateTimeHelpers
{
    public static DateTime GetMostRecentThirdWednesday(bool debug = false)
    {
        var now = DateTime.Now;
        var month = now.Month;
        var year = now.Year;

        var currentMonthThirdWednesday = now.GetThirdWednesdayForMonth();

        if (now < currentMonthThirdWednesday || debug)
        {
            // If today is before the 3rd Wednesday, check the previous month
            month--;
            if (month < 1)
            {
                month = 12;
                year--;
            }

            currentMonthThirdWednesday = new DateTime(year, month, 1).GetThirdWednesdayForMonth();
        }
        
        return currentMonthThirdWednesday;
    }
}

public static class DateTimeExtensions
{
    public static DateTime GetThirdWednesdayForMonth(this DateTime month)
    {
        var firstWednesday = new DateTime(month.Year, month.Month, 1);

        while (firstWednesday.DayOfWeek != DayOfWeek.Wednesday)
        {
            firstWednesday = firstWednesday.AddDays(1);
        }

        return firstWednesday.AddDays(14);
    }
}