using FluentValidation;
using MyBlogProject_Frontend.Models.DTOs;

namespace MyBlogProject_Frontend.Models.Validations
{
	public class ContactValidator : AbstractValidator<ContactAddDto>
	{
		public ContactValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Soyad Alanı Boş Geçilemez");

			RuleFor(x => x.Name).MinimumLength(2).WithMessage("Ad Soyad 2 Karakterden Uzun Olmalıdır.");

			RuleFor(x => x.Name).MaximumLength(60).WithMessage("Ad Soyad 60 Karakterden Fazla Olamaz");

			RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Bırakılamaz").EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
				.WithMessage("Lütfen Geçerli Bir Email Formatı Giriniz");
			

			RuleFor(y => y.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez");

			RuleFor(z => z.Message).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez");


		}
	}
}
