using GalaxyNews.Database.Models;
using GalaxyNews.Miscellaneous;

namespace GalaxyNews.Models
{
    public class ArticleModel
    {
        public readonly Article Article;
        public readonly string AbsoluteImagePath;
        public readonly long FromPage;
        public readonly string GoBackLink;

        public ArticleModel(Article article, long fromPage)
        {
            Article = article;
            AbsoluteImagePath = Formatter.GetAbsoluteImagePath(Article.Image);
            FromPage = fromPage;
            GoBackLink = Formatter.GetPageLink(fromPage);
        }
    }
}
