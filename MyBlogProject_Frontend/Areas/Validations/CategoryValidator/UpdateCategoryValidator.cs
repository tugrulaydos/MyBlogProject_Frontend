using FluentValidation;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Category;

namespace MyBlogProject_Frontend.Areas.Validations.CategoryValidator
{
	public class UpdateCategoryValidator: AbstractValidator<CategoryUpdateDto>
	{
		public UpdateCategoryValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
			RuleFor(y => y.Name).MinimumLength(2).WithMessage("Kategori Adı 2 Karakterden Uzun Olmalıdır");
			RuleFor(z => z.Name).MaximumLength(20).WithMessage("Kategori Adı 20 Karakterden Fazla Olamaz");

		}

	}
}
