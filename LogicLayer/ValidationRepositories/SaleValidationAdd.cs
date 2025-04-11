using DataLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ValidationRepositories
{
    public class SaleValidationAdd: AbstractValidator<Product>
    {
        public SaleValidationAdd(int stock)
        {
            RuleFor(p => p.stock)
            .NotEmpty().WithMessage("La cantidad no puede estar vacía")
            .GreaterThan(0).WithMessage("La cantidad debe ser mayor a cero")
            .Must(c => c % 1 == 0).WithMessage("La cantidad no puede tener decimales")
            .LessThanOrEqualTo(stock).WithMessage($"La cantidad no puede superar el stock disponible ({stock})");

            RuleFor(p => p.name)
                .NotEmpty().WithMessage("El nombre no puede estar vacío");

        }
    }
}
