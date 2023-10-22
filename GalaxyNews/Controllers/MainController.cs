using GalaxyNews.Database.Models;
using Microsoft.AspNetCore.Mvc;
using GalaxyNews.Models;

namespace GalaxyNews.Controllers
{
    [Route("/{action=Index}")]
    public class MainController : Controller
    {
        private readonly GalaxyNewsContext _dbContext;
        private const int NewsPortionSize = 4;

        public MainController(GalaxyNewsContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int page)
        {
            var totalNewsCount = _dbContext.News.Count();

            var totalPages = (int)Math.Ceiling(totalNewsCount / 4d);
            var currentPage = Math.Clamp(page, 1, totalPages);

            var offset = (currentPage - 1) * NewsPortionSize;

            var latestNews = _dbContext.News
                .OrderByDescending(x => x.Date)
                .Skip(offset)
                .Take(NewsPortionSize);

            return View(new IndexModel(
                news: latestNews,
                totalPages: totalPages,
                currentPage: currentPage
            ));
        }

        [HttpGet]
        public IActionResult Article(long id, long from)
        {
            var articles = _dbContext.News.Where(x => x.Id == id);

            if (!articles.Any())
            {
                return NotFound();
            }

            return View(new ArticleModel(articles.First(), from));
        }
    }
}
