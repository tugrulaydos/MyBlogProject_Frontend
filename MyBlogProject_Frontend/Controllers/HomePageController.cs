using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject_Frontend.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
