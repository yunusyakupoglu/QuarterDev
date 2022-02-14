using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
	public class ObjProjectImage : BaseEntity
	{
		public string ImagePath { get; set; }
		public int ProjectId { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
