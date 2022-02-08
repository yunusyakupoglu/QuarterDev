using FluentValidation;
using UI.Models;

namespace UI.ValidationRules
{
    public class SubtitleItemViewModelValidator : AbstractValidator<SubtitleItemViewModel>
    {
        public SubtitleItemViewModelValidator()
        {
            RuleFor(x => x.CategoySubtitleId).NotEmpty().WithMessage("Kategori başlığı seçimi zorunludur");
            RuleFor(x => x.Description).NotEmpty().WithMessage("İçerik boş geçilemez.");
        }
    }
}
