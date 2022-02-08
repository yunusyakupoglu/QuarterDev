﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjQuarterCategoryTitle : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int QuarterCategoryId { get; set; }
        public List<ObjCategorySubtitle> Subtitles { get; set; }
    }
}
