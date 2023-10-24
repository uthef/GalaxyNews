using GalaxyNews.Models;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyNews.Controllers
{
    [Route("/Error/{code:int}")]
    public class ErrorController : Controller
    {
        public IActionResult HandleError(int code)
        {
            var model = new ErrorModel(code, "Невозможно отобразить запрошенную страницу");
            return View("Error", model);
        }
    }
}
