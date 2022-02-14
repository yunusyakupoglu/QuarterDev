using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class ProjectImageListDto : IDto
	{
		public int Id { get; set; }
		public string ImagePath { get; set; }
		public int ProjectId { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool Status { get; set; }
	}
}
