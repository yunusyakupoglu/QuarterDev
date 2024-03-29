﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class QuarterCategoryTitleListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuarterCategoryId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
