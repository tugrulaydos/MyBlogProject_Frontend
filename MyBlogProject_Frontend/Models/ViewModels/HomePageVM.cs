
using MyBlogProject_Frontend.Models.DTOs;

namespace MyBlogProject_Frontend.Models.ViewModels
{
    public class HomePageVM
    {
        public ArticleDto? articleDto { get; set; }
        public List<CategoryDto> Categories { get; set; }

        public List<ArticleDto> Articles { get; set; }

    }
}
