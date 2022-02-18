﻿using DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ValidationRules
{
    public class CompanyServiceCreateDtoValidator : AbstractValidator<CompanyServiceCreateDto>
    {
        public CompanyServiceCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.IconCode).NotEmpty();
        }
    }
}
