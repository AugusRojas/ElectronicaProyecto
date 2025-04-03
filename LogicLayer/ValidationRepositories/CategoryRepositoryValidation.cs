
using FluentValidation;
using FluentValidation.Results;
using DataLayer.Models;


namespace LogicLayer.ValidationRepositories
{

    public class CategoryRepositoryValidation : AbstractValidator<Category>
    {
        public CategoryRepositoryValidation()
        {
            RuleFor(c => c.name)
                .NotEmpty().WithMessage("La categoria no puede ser vacia")
                .MinimumLength(3).WithMessage("La categoria nececita como minimo 3 caracteres y maximo 20 caracteres")
                .MaximumLength(50).WithMessage("La categoria nececita como minimo 3 caracteres y maximo 20 caracteres");
        }
    }
}
