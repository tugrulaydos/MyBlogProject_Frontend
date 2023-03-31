namespace MyBlogProject_Frontend.Areas.Admin.Models.DTOs.Category
{
    public class ApiCategoryGetDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ModifiedDate { get; set; }

		public DateTime DeletedDate { get; set; }


	}
}
