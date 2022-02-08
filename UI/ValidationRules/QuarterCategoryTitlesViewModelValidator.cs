using FluentValidation;
using UI.Models;

namespace UI.ValidationRules
{
    public class QuarterCategoryTitlesViewModelValidator : AbstractValidator<QuarterCategoryTitlesViewModel>
    {
        public QuarterCategoryTitlesViewModelValidator()
        {
            RuleFor(x => x.QuarterCategoryId).NotEmpty().WithMessage("Üst başlık seçimi zorunludur.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("İçerik boş geçilemez.");
        }
    }
}
