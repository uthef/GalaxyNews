using GalaxyNews.Database.Models;

namespace GalaxyNews.Models
{
    public class IndexModel
    {
        public readonly IEnumerable<Article> News;
        public readonly int TotalPages;
        public readonly int CurrentPage;
        public readonly Article? LatestArticle;

        public IndexModel(IEnumerable<Article> news, Article? latestArticle, int totalPages, int currentPage)
        {
            News = news;
            TotalPages = totalPages;
            CurrentPage = currentPage;
            LatestArticle = latestArticle;
        }

        public string FormatLink(Article article)
        {
            var link = $"/article?id={article.Id}";
            if (CurrentPage > 1) link += $"&from={CurrentPage}";
            return link;
        }
    }
}
