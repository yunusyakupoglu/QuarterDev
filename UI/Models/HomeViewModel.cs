using DTOs;
using System.Collections.Generic;

namespace UI.Models
{
    public class HomeViewModel
    {
        public List<AboutUsListDto> abouts { get; set; }
        public List<AUDescriptionListDto> aUDescriptions { get; set; }
        public List<QuarterCategoryListDto> quarterCategories { get; set; }
        public List<QuarterCategoryTitleListDto> quarterCategoryTitles { get; set; }
        public List<CategorySubtitleListDto> categorySubtitles { get; set; }
        public List<SubtitleDescriptionListDto> subtitleDescriptions { get; set; }
        public List<SubtitleItemListDto> subtitleItems { get; set; }
        public List<ProjectListDto> projects { get; set; }
        public List<ProjectImageListDto> projectImages { get; set; }
        public List<FaqListDto> faqs { get; set; }
        public List<CompanyServiceListDto> companyServices { get; set; }
        public int defaultCategoryTitle { get; set; }


    }
}
