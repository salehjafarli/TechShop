using TechShop.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Extensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> NameBoilerPlateValidation<T>(this IRuleBuilder<T, string> ruleBuilder, string propname = "name") where T : IDto
        {
                return ruleBuilder
                .NotEmpty().WithMessage($"{propname} should not be empty")
                .NotNull().WithMessage($"{propname} cannot be null")
                .Length(3, 30).WithMessage($"{propname} length should be between 3 and 30");
        }
        public static IRuleBuilderOptions<T, int> IdBoilerPlateValidation<T>(this IRuleBuilder<T, int> ruleBuilder, string propname = "id") where T : IDto
        {
            return ruleBuilder
            .NotNull().WithMessage($"{propname} cannot be null")
            .GreaterThan(-1).WithMessage($"{propname} should be greater than -1");
        }
    }
}
