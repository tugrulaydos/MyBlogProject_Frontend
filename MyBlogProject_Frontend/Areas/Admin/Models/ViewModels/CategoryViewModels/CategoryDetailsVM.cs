using MyBlogProject_Frontend.Areas.Admin.Models.DTOs;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Category;

namespace MyBlogProject_Frontend.Areas.Admin.Models.ViewModels.CategoryViewModels
{
	public class CategoryDetailsVM
	{
		public ApiCategoryGetDto categoryDto { get; set; }

		public bool DetailPage { get; set; }

	}
}
