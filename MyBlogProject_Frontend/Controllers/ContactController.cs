using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyBlogProject_Frontend.Models.Context;
using MyBlogProject_Frontend.Models.DTOs;
using MyBlogProject_Frontend.Models.Entities;
using MyBlogProject_Frontend.Models.Validations;

namespace MyBlogProject_Frontend.Controllers
{
    public class ContactController : Controller
    {
		private readonly ConsumerDbContext _consumerDbContext;
		public ContactController(ConsumerDbContext consumerDbContext)
        {
            this._consumerDbContext= consumerDbContext;

        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult ContactAdd([FromBody] ContactAddDto contactAddDto)
        {
            ContactValidator validator = new();
            ValidationResult result = validator.Validate(contactAddDto);

            if (result.IsValid) 
            {
				
				contactAddDto.CreatedDate = DateTime.Now;

				//AutoMapper kullanmadık Bir tabe için gerek yoq
				Contact cnt = new();
                cnt.Subject = contactAddDto.Subject;
                cnt.Email= contactAddDto.Email;
                cnt.CreatedDate = contactAddDto.CreatedDate;
                cnt.Message= contactAddDto.Message;
                cnt.Name= contactAddDto.Name;
                
                _consumerDbContext.Contact.Add(cnt);
                _consumerDbContext.SaveChanges();
				return Json(new { isSuccess = true });
			}
            else 
            {
                string errorMessages = string.Empty;
                foreach(var error in result.Errors) 
                {
                    errorMessages += $"<b>-{error.ErrorMessage}</b><br/>";
                }
				return Json(new { isSuccess = false,message=errorMessages});
			}

		
		}
    }
}
