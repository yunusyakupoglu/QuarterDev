using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    internal class SubtitleDescriptionCreateDtoValidator : AbstractValidator<SubtitleDescriptionCreateDto>
    {
        public SubtitleDescriptionCreateDtoValidator()
        {
            RuleFor(x=>x.Description).NotEmpty();
        }
    }
}
