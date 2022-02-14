using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace UI.Models
{
	public class ProjectImageViewModel
	{
		public string ImagePath { get; set; }
		public int ProjectId { get; set; }
		public DateTime CreatedDate { get; set; }
		public IFormFile FileDoc { get; set; }
		public bool Status { get; set; }
		public SelectList Projects { get; set; }
	}
}
