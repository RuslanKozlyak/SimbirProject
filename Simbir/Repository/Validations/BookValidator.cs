using Domain.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Validations
{
    class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Id).NotNull().WithMessage($"Поле Id не может иметь значение NULL!");
            RuleFor(book => book.Title).NotNull().WithMessage($"Поле Title не может иметь значение NULL!");
            RuleFor(book => book.AuthorId).NotNull().WithMessage($"Поле AuthorId не может иметь значение NULL!");
        }
    }
}
