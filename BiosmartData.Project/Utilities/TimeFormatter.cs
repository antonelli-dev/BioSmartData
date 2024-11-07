public static class TimeFormatter
{
    public static string FormatWithMinutes(TimeSpan time) => DateTime.Today.Add(time).ToString("h:mm tt").ToLower();
    public static string FormatHourly(TimeSpan time) => DateTime.Today.Add(time).ToString("h tt");
}
