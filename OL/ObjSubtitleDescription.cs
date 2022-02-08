using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjSubtitleDescription : BaseEntity
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoySubtitleId { get; set; }
    }
}
