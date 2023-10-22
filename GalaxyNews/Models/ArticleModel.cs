using GalaxyNews.Database.Models;

namespace GalaxyNews.Models
{
    public class ArticleModel
    {
        public readonly Article Article;
        public readonly string AbsoluteImagePath;
        private const string BaseImagePath = "images/attachments";
        public readonly long FromPage;
        public readonly string GoBackLink;

        public ArticleModel(Article article, long fromPage)
        {
            Article = article;
            AbsoluteImagePath = Path.Join(BaseImagePath, article.Image);
            FromPage = fromPage;
            GoBackLink = fromPage <= 1 ? "/" : $"/?page={fromPage}";
        }
    }
}
