using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Category;

namespace MyBlogProject_Frontend.Areas.Admin.Models.DTOs
{
    public class ApiArticleGetDto
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public bool IsDeleted { get; set; }         

        public string Content { get; set; }

        public string? PhotoPath { get; set; }

        public CategoryDto Category { get; set; }

        public int CategoryId { get; set; }        

    }
}
