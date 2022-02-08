using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CategorySubtitleUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public int QuarterCategoryTitleId { get; set; }
        public bool Status { get; set; }
        public List<ObjSubtitleDescription> Descriptions { get; set; }
        public List<ObjSubtitleItem> Items { get; set; }
    }
}
