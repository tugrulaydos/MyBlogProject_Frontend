using Microsoft.AspNetCore.Mvc;
using MyBlogProject_Frontend.Models.DTOs;

namespace MyBlogProject_Frontend.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult ContactAdd([FromBody] ContactAddDto contactAddDto)
        {

			return Json(new { isSuccess = false });
		}
    }
}
