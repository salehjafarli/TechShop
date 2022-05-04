using TechShop.DTO;
using TechShop.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Id).IdBoilerPlateValidation();
            RuleFor(x => x.Name).NameBoilerPlateValidation();
        }
    }
}
