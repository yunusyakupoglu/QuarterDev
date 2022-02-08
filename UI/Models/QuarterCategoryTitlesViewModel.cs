using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Models
{
    public class QuarterCategoryTitlesViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int QuarterCategoryId { get; set; }
        public SelectList QuarterCategories { get; set; }
    }
}
