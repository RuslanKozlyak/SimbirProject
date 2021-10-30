using Domain.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Validations
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(author => author.Id).NotNull().WithMessage($"Поле Id не может иметь значение NULL!");
            RuleFor(author => author.FirstName).NotNull().WithMessage($"Поле FirstName не может иметь значение NULL!");
            RuleFor(author => author.LastName).NotNull().WithMessage($"Поле LastName не может иметь значение NULL!");
        }
    }
}
