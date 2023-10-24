using GalaxyNews.Database.Models;
using Microsoft.AspNetCore.Mvc;
using GalaxyNews.Models;

namespace GalaxyNews.Controllers
{
    [Route("/{action=Index}")]
    public class MainController : Controller
    {
        private readonly GalaxyNewsContext DbContext;
        private const int NewsPortionSize = 4;

        public MainController(GalaxyNewsContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int page)
        {
            var totalNewsCount = DbContext.News.Count();

            var totalPages = (int)Math.Ceiling(totalNewsCount / 4d);
            var currentPage = Math.Clamp(page, 1, totalPages);

            var offset = (currentPage - 1) * NewsPortionSize;

            var latestNews = DbContext.News
                .OrderByDescending(x => x.Date)
                .Skip(offset)
                .Take(NewsPortionSize);

            Article? latestArticle = latestNews.FirstOrDefault();

            return View(new IndexModel(
                news: latestNews,
                latestArticle: latestArticle,
                totalPages: totalPages,
                currentPage: currentPage
            ));
        }

        [HttpGet]
        public IActionResult Article(long id, long from)
        {
            var articles = DbContext.News.Where(x => x.Id == id);

            if (!articles.Any())
            {
                return NotFound();
            }

            return View(new ArticleModel(
                article: articles.First(), 
                fromPage: from
            ));
        }
    }
}
