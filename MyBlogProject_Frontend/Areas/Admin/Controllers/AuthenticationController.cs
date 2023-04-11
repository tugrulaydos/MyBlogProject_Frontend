using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject_Frontend.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AuthenticationController : Controller
	{
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
	}
}
