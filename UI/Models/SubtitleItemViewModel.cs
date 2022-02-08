using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace UI.Models
{
    public class SubtitleItemViewModel
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public int CategoySubtitleId { get; set; }
        public SelectList CategorySubtitles { get; set; }

    }
}
