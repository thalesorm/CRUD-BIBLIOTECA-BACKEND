using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class BookValidators:AbstractValidator<Book>
    {
        public BookValidators()
        {
            RuleFor(prop => prop.Author)
            .NotEmpty().WithMessage("Autor Vazio")
            .NotNull().WithMessage("Campo autor vazio não permitido");

            RuleFor(prop => prop.Genre)
            .NotEmpty().WithMessage("Genero Vazio")
            .NotNull().WithMessage("Campo Genero vazio não permitido");

            RuleFor(prop => prop.Title)
            .NotEmpty().WithMessage("Titulo Vazio")
            .NotNull().WithMessage("Campo titulo vazio não permitido");
        }
    }
}
