namespace MyBlogProject_Frontend.Models.DTOs
{
	public class AboutDto
	{
		public int ID { get; set; }

		public string? Content { get; set; }

		public IFormFile AboutPhoto { get; set; }

		public string? PhotoPath {get;set;}
	}
}
