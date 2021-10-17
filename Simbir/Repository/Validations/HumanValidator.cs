using Domain.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Validations
{
    class HumanValidator : AbstractValidator<Human>
    {
        public HumanValidator()
        {
            RuleFor(book => book.Id).NotNull().WithMessage($"Поле Id не может иметь значение NULL!");
            RuleFor(book => book.FirstName).NotNull().WithMessage($"Поле FirstName не может иметь значение NULL!");
            RuleFor(book => book.LastName).NotNull().WithMessage($"Поле LastName не может иметь значение NULL!");
        }
    }
}
