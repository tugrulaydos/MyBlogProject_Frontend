using FluentValidation;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article;
using MyBlogProject_Frontend.Models.DTOs;

namespace MyBlogProject_Frontend.Models.Validations
{
	public class UpdateAboutValidator : AbstractValidator<AboutDto>
	{
		public UpdateAboutValidator()
		{
			RuleFor(x=>x.Content).NotEmpty().WithMessage("İçerik Boş Geçilemez");

			RuleFor(b => b.AboutPhoto.ContentType).Must(c => c.StartsWith("image/")).When(b => b.AboutPhoto != null).WithMessage("Lütfen Resim Dosyası Seçiniz");
			RuleFor(c => c.AboutPhoto.Length).LessThan(2 * 1024 * 1024).When(c => c.AboutPhoto != null).WithMessage("Dosya Boyutu 2 Megabyte'dan Küçük Olmalıdır");


		}
	}
}
