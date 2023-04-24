using FluentValidation;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article;

namespace MyBlogProject_Frontend.Areas.Validations.ArticleValidator
{
	public class UpdateArticleValidator:AbstractValidator<ArticleUpdateDto>
	{
		public UpdateArticleValidator()
		{
			RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Geçilemez");
			RuleFor(y => y.Title).MinimumLength(2).WithMessage("Başlık 2 Karakterden Uzun Olmalıdır");
			RuleFor(z => z.Title).MaximumLength(100).WithMessage("Başlık 100 karakterden Fazla Olamaz");

			RuleFor(a => a.Content).NotEmpty().WithMessage("İçerik Boş Geçilemez");


		}
	}
}
