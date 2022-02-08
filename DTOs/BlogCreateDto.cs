using Microsoft.AspNetCore.Http;

namespace DTOs
{
    public class BlogCreateDto : IDto
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public IFormFile FileDoc { get; set; }

    }
}
