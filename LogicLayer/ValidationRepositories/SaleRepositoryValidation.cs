using DataLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ValidationRepositories
{
    public class SaleRepositoryValidation : AbstractValidator<Product>
    {
        public SaleRepositoryValidation()
        {
            RuleFor(p => p.stock)
            .NotEmpty().WithMessage("La cantidad no puede estar vacía")
            .GreaterThan(0).WithMessage("La cantidad debe ser mayor a cero")
            .Must(c => c % 1 == 0).WithMessage("La cantidad no puede tener decimales");

        }

    }
}
