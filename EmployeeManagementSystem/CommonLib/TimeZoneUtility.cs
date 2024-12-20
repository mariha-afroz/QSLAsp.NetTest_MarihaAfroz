namespace CommonLib
{
    public static class TimeZoneUtility
    {
        public static DateTime DateTimeNow
        {
            get
            {
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);

                return currentDateTime;
            }
        }

        public static string DateTimeNowString
        {
            get
            {
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);

                return currentDateTime.ToString("MMM-dd-yyyy hh:mm tt");

            }
        }

        public static DateTime DefaultTime
        {
            get
            {
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);

                DateTime defaultTime = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day).AddHours(9);

                return defaultTime;
            }
        }
    }
}
