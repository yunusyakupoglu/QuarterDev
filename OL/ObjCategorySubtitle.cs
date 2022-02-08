using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjCategorySubtitle : BaseEntity
    {
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public int QuarterCategoryTitleId { get; set; }
        public List<ObjSubtitleDescription> Descriptions { get; set; }
        public List<ObjSubtitleItem> Items { get; set; }

    }
}
