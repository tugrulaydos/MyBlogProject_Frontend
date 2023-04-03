using MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Category;

namespace MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Article
{
	public class ArticleSoftDeleteDto
	{
		public int ID { get; set; }

		public bool IsDeleted { get; set; }		

	}
}
