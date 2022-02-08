using FluentValidation;
using UI.Models;

namespace UI.ValidationRules
{
    public class CategorySubtitleViewModelValidator : AbstractValidator<CategorySubtitleViewModel>
    {
        public CategorySubtitleViewModelValidator()
        {
            RuleFor(x => x.QuarterCategoryTitleId).NotEmpty().WithMessage("Üst başlık seçimi zorunludur.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("İçerik boş geçilemez.");
        }
    }
}
