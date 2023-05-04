namespace MyBlogProject_Frontend.Models.Entities
{
    public class Contact
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
