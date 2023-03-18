using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Category;

namespace MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article
{
    public class ArticleUpdateDto
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public int ImageId { get; set; }

        public IList<CategoryDto> Categories { get; set; }



    }
}
