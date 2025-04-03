using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using FluentValidation;
using FluentValidation.Results;


namespace LogicLayer.ValidationRepositories
{
    public class CategoriesRepositoryValidation : AbstractValidator<List<Category>>
    {
        public  CategoriesRepositoryValidation()
        {
            RuleFor(c => c)
                .NotEmpty().WithMessage("La lista de categorias no puede ser vacia")
                .Must(c => c.Count <= 20).WithMessage("La lista de categorias no puede tener mas de 20 elementos");
        }
    }
}
