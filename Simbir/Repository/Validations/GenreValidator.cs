using Domain.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Validations
{
    class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(book => book.Id).NotNull().WithMessage($"Поле Id не может иметь значение NULL!");
            RuleFor(book => book.GenreName).NotNull().WithMessage($"Поле GenreName не может иметь значение NULL!");
        }
    }
}
