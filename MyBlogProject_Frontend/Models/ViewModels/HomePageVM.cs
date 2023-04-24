
using MyBlogProject_Frontend.Models.DTOs;

namespace MyBlogProject_Frontend.Models.ViewModels
{
    public class HomePageVM
    {
        public List<CategoryDto> Categories { get; set; }

        public List<ArticleDto> Articles { get; set; }

    }
}
