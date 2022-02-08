using FluentValidation;
using UI.Models;

namespace UI.ValidationRules
{
    public class SubtitleDescriptionViewModelValidator : AbstractValidator<SubtitleDescriptionViewModel>
    {
        public SubtitleDescriptionViewModelValidator()
        {
            RuleFor(x => x.CategoySubtitleId).NotEmpty().WithMessage("Kategori başlığı seçimi zorunludur");
            RuleFor(x => x.Description).NotEmpty().WithMessage("İçerik boş geçilemez.");
        }
    }
}
