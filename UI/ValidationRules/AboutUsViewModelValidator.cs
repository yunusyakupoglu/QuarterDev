using FluentValidation;
using UI.Models;

namespace UI.ValidationRules
{
    public class AboutUsViewModelValidator : AbstractValidator<AboutUsDescriptionViewModel>
    {
        public AboutUsViewModelValidator()
        {
            RuleFor(x=>x.AboutUsId).NotEmpty().WithMessage("Üst başlık seçimi zorunludur.");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("İçerik boş geçilemez.");
        }
    }
}
