namespace MyBlogProject_Frontend.Models.DTOs
{
    public class ArticleDto
    {
        public int ID { get; set; }
        public string Title { get; set; }                 
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? PhotoPath { get; set; }
        public CategoryDto Category { get; set; }
        public int CategoryId { get; set; }
    }
}
