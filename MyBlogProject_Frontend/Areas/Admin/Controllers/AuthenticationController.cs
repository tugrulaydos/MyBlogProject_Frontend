using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Login;
using MyBlogProject_Frontend.Areas.Validations.LoginValidator;
using MyBlogProject_Frontend.Models.Context;

namespace MyBlogProject_Frontend.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AuthenticationController : Controller
	{
		private readonly ConsumerDbContext _consumerDbContext;

		public AuthenticationController(ConsumerDbContext consumerDbContext)
		{
			_consumerDbContext = consumerDbContext;

		}


		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Login(LoginDto dto)
		{
			//LoginValidator validator = new();
	        //ValidationResult result= validator.Validate(dto);

			if (ModelState.IsValid)
			{
				var user = _consumerDbContext.Users.SingleOrDefault(u=>u.Email== dto.Email && u.Password==dto.Password);

				if(user== null)
				{
					return View();

				}

				HttpContext.Session.SetString("username", user.FullName);
				return RedirectToAction("Index", "Article", new { area = "Admin" });
			}
			else 
			{
				var messages = ModelState.ToList();

                return View(dto);

			}			

		}


		public IActionResult Logout() 
		{
			HttpContext.Session.Remove("username");

			return RedirectToAction("Login", "Authentication");


		}
	}
}
