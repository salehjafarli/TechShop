using TechShop.DTO;
using TechShop.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Id).IdBoilerPlateValidation();
            RuleFor(x => x.Name).NameBoilerPlateValidation();
            RuleFor(x => x.CategoryId).IdBoilerPlateValidation("categoryid");
        }
    }
}
