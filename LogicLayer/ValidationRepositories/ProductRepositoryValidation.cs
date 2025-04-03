using DataLayer.Interfaces;
using DataLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ValidationRepositories
{

    public class ProductRepositoryValidation : AbstractValidator<Product>
    {
        public ProductRepositoryValidation()
        {
            RuleFor(p=>p.name)
                .NotEmpty().WithMessage("El nombre del producto no puede ser vacio")
                .MinimumLength(3).WithMessage("El nombre del producto nececita como minimo 3 caracteres y maximo 20 caracteres")
                .MaximumLength(50).WithMessage("El nombre del producto nececita como minimo 3 caracteres y maximo 20 caracteres");
            RuleFor(p => p.price)
                .NotEmpty().WithMessage("El precio del producto no puede ser vacio")
                .GreaterThan(0).WithMessage("El precio del producto no puede ser menor o igual a 0")
                .LessThan(5000000).WithMessage("El precio del producto no puede ser mayor a 5,000,000");
            RuleFor(p => p.stock)
                .NotEmpty().WithMessage("El stock del producto no puede ser vacio")
                .GreaterThan(0).WithMessage("El stock del producto no puede ser menor o igual a 0")
                .LessThan(1000).WithMessage("El stock del producto no puede ser mayor a 1,000 unidades");
            RuleFor(p => p.idCategory)
                .NotEmpty().WithMessage("El id de la categoria no puede ser vacio");

        }
    }
}
