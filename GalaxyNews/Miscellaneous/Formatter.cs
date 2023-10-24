namespace GalaxyNews.Miscellaneous
{
    public static class Formatter
    {
        private const string BaseImagePath = @"/images/attachments/";

        public static string GetAbsoluteImagePath(string path) => Path.Join(BaseImagePath, path);
        public static string GetPageLink(long page) => (page <= 1) ? "/" : $"/?page={page}";
        public static string GetDate(DateOnly date) => date.ToString("dd.MM.yyyy");
    }
}
