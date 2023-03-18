using MyBlogProject_Frontend.Areas.Admin.Models.DTOs;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article;
using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Category;

namespace MyBlogProject_Frontend.Areas.Admin.Models.ViewModels
{
    public class CategoryIndexVM
    {
        public List<ApiArticleGetDto> Articles { get; set; }

        public List<ApiCategoryGetDto> Categories { get; set; }
    }
}
