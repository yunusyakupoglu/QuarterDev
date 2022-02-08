using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjAboutUs : BaseEntity
    {
        public string Title { get; set; }
        public List<ObjAUDescription> Descriptions { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
