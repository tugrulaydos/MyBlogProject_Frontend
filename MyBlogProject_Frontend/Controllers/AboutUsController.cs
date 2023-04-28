using Microsoft.AspNetCore.Mvc;
using MyBlogProject_Frontend.Models.Context;

namespace MyBlogProject_Frontend.Controllers
{
	public class AboutUsController : Controller
	{
		private readonly ConsumerDbContext _consumerDbContext;
		public AboutUsController(ConsumerDbContext consumerDbContext)
		{
			this._consumerDbContext= consumerDbContext;

		}
		public IActionResult Index()
		{
			var about = _consumerDbContext.AboutUs.SingleOrDefault(x => x.ID >= 1); 
			return View(about);
		}
	}
}
