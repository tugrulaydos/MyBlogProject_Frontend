using MyBlogProject_Frontend.Areas.Admin.Models.DTOs;

namespace MyBlogProject_Frontend.Areas.Admin.Models.ViewModels.ArticleViewModels
{
	public class DetailsVM
	{
		public ApiArticleGetDto articleGetDto { get; set; }

		public bool DetailPage { get; set; }
	}
}
