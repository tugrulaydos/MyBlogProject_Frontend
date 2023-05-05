using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject_Frontend.Areas.Admin.AttributeFilters;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article;
using MyBlogProject_Frontend.Models.Context;
using Newtonsoft.Json;
using System.Text;

namespace MyBlogProject_Frontend.Areas.Admin.Controllers
{
    [Area("admin")]
    public class MessageBoxController : Controller
	{
        private readonly ConsumerDbContext _consumerDbContext;
        public MessageBoxController(ConsumerDbContext consumerDbContext)
		{
		      this._consumerDbContext = consumerDbContext;
		}

		public IActionResult Index()
		{
			var Contacts = _consumerDbContext.Contact.ToList();

			return View(Contacts);
		}

	
		public IActionResult Delete([FromBody] int id)
		{
			var data = _consumerDbContext.Contact.SingleOrDefault(x => x.ID == id);

			_consumerDbContext.Remove(data);

			if (_consumerDbContext.SaveChanges() >= 0) 
			{
				return Json(new { isSuccess = true });
			}

			return Json(new { isSuccess = false });			

		}

		public IActionResult Details(int Id)
		{
			var data = _consumerDbContext.Contact.SingleOrDefault(y=>y.ID== Id);

			return View(data);
		}

	}
}
