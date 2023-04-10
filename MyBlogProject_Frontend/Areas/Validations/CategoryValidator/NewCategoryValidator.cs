using FluentValidation;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs;

namespace MyBlogProject_Frontend.Areas.Validations.CategoryValidator
{
	public class NewCategoryValidator:AbstractValidator<CategoryAddDto>
	{
		public NewCategoryValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
			RuleFor(y => y.Name).MinimumLength(2).WithMessage("Kategori Adı 2 Karakterden Uzun Olmalıdır");
			RuleFor(z => z.Name).MaximumLength(20).WithMessage("Kategori Adı 20 Karakterden Fazla Olamaz");
		}
	

	}
}
