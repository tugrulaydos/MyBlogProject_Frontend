using FluentValidation;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article;

namespace MyBlogProject_Frontend.Areas.Validations.ArticleValidator
{
	public class NewArticleValidator:AbstractValidator<ArticleAddDto>
	{
		public NewArticleValidator()
		{
			RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Geçilemez");
			RuleFor(y => y.Title).MinimumLength(2).WithMessage("Başlık 2 Karakterden Uzun Olmalıdır");
			RuleFor(z => z.Title).MaximumLength(25).WithMessage("Başlık 25 karakterden Fazla Olamaz");

			RuleFor(a => a.Content).NotEmpty().WithMessage("İçerik Boş Geçilemez");

			
			RuleFor(b => b.ArticlePhoto.ContentType).Must(c => c.StartsWith("image/")).When(b=>b.ArticlePhoto!=null).WithMessage("Lütfen Resim Dosyası Seçiniz");
			RuleFor(c => c.ArticlePhoto.Length).LessThan(2 * 1024 * 1024).When(c=>c.ArticlePhoto!=null).WithMessage("Dosya Boyutu 2 Megabyte'dan Küçük Olmalıdır");

		}
	}
}
