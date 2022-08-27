using FluentValidation;
using Repositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Validators
{
    public class PageableModelValidator : AbstractValidator<PageableModel>
    {
        public PageableModelValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).GreaterThanOrEqualTo(1);
        }
    }
}
