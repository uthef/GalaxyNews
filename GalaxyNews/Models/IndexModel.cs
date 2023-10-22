using GalaxyNews.Database.Models;

namespace GalaxyNews.Models
{
    public class IndexModel
    {
        public readonly IEnumerable<Article> News;
        public readonly int TotalPages;
        public readonly int CurrentPage;

        public IndexModel(IEnumerable<Article> news, int totalPages, int currentPage)
        {
            News = news;
            TotalPages = totalPages;
            CurrentPage = currentPage;
        }

        public string FormatLink(long id)
        {
            var link = $"/article?id={id}";
            if (CurrentPage > 1) link += $"&from={CurrentPage}";
            return link;
        }
    }
}
