using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjQuarterCategory : BaseEntity
    {
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ObjQuarterCategoryTitle> CategoryTitles { get; set; }
    }
}
