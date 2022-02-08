using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace UI.Models
{
    public class CategorySubtitleViewModel
    {
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public int QuarterCategoryTitleId { get; set; }
        public SelectList QuarterCategoryTitles { get; set; }

    }
}
