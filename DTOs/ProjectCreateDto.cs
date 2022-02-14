using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class ProjectCreateDto : IDto
	{
        public string BrandName { get; set; }
        public string ProjectType { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
	    public IFormFile FileDoc { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
