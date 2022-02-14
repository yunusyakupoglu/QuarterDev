using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjProject : BaseEntity
    {
        public string BrandName { get; set; }
        public string ProjectType { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public List<ObjProjectImage> ProjectImages { get; set; }
	}
}
