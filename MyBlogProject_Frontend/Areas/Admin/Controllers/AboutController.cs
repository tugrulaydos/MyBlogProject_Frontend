using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyBlogProject_Frontend.Areas.Admin.AttributeFilters;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article;
using MyBlogProject_Frontend.Areas.Validations.ArticleValidator;
using MyBlogProject_Frontend.Models.Context;
using MyBlogProject_Frontend.Models.DTOs;
using MyBlogProject_Frontend.Models.Validations;
using Newtonsoft.Json;
using System.Text;

namespace MyBlogProject_Frontend.Areas.Admin.Controllers
{

    [Area("admin")]
    public class AboutController : Controller
	{
		private readonly ConsumerDbContext _consumerDbContext;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public AboutController(ConsumerDbContext consumerDbContext, IWebHostEnvironment webHostEnvironment)
		{
			_consumerDbContext = consumerDbContext;
			_webHostEnvironment = webHostEnvironment;
		}

		[Session("username", "Authentication", "Login")]
		public IActionResult Index()
		{

			var About = _consumerDbContext.AboutUs.SingleOrDefault(x =>x.ID >= 1);

			return View(About);

		}

		[Session("username", "Authentication", "Login")]
		[HttpGet]
		public IActionResult Update()
		{
			var About = _consumerDbContext.AboutUs.SingleOrDefault(x => x.ID >= 1);

			TempData.Clear();
			TempData.Add("AboutPhotoPath", About.PhotoPath);

			return View(About);		
		}

		[Session("username", "Authentication", "Login")]
		[HttpPost]
		public IActionResult Update(AboutDto aboutDto)
		{
			UpdateAboutValidator validator = new();
			ValidationResult result = validator.Validate(aboutDto);

			if (result.IsValid)
			{
				if (aboutDto.AboutPhoto != null)
				{
					var file = aboutDto.AboutPhoto;

					var fileName = Path.GetFileName(file.FileName);
					var fileExtension = Path.GetExtension(fileName);
					//Unique ID
					var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
					//Resmin Kaydedileceği Yolu Ayarla
					var uploadsDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "AboutPhotos");
					var filePath = Path.Combine(uploadsDirectory, uniqueFileName);
					//if There is no folder, Create it
					if (!Directory.Exists(filePath))
					{
						Directory.CreateDirectory(uploadsDirectory);
					}

					//Save the Directory to the disk
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						file.CopyToAsync(stream);
					}

					//var About = _consumerDbContext.AboutUs.SingleOrDefault(x=>x.ID >= 1);

					aboutDto.PhotoPath = uniqueFileName;
					aboutDto.Content= aboutDto.Content;
					//_consumerDbContext.SaveChanges();
					

				}
				else 
				{
					aboutDto.PhotoPath = TempData.Peek("AboutPhotoPath") as string;
				}

				var About = _consumerDbContext.AboutUs.SingleOrDefault(x => x.ID >= 1);
				About.PhotoPath= aboutDto.PhotoPath;
				About.Content = aboutDto.Content;
				_consumerDbContext.SaveChanges();
				return Json(new { isSuccess = true });


			}
			else
			{
				string errorMessages = string.Empty;
				foreach (var error in result.Errors)
				{
					errorMessages += $"<b>║{error.ErrorMessage}║</b><br/>";
				}

				return Json(new { isSuccess = false, message = errorMessages });

			}

			//return Json(new { isSuccess = false });



		}
	}
}
