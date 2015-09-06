namespace SeleniumScreenshotDashboard.Extensions
{
    public static class StringExtension
    {
        public static int ToInt(this string value)
        {
            int defaultValue;
            int.TryParse(value, out defaultValue);

            return defaultValue;
        }
    }
}