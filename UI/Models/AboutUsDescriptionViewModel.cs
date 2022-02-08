using DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace UI.Models
{
    public class AboutUsDescriptionViewModel
    {
        public string Description { get; set; }
        public bool Status { get; set; }
        public int AboutUsId { get; set; }
        public SelectList Abouts { get; set; }
    }
}
