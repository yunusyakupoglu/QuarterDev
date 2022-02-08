using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjAUDescription : BaseEntity
    {
        public string Description { get; set; }
        public int AboutUsId { get; set; }
        public ObjAboutUs ObjAboutUs { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
