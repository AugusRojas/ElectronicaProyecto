using DataLayer.Interfaces;
using DataLayer.Models;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Vml;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LogicLayer.ValidatorService
{
    public class CategoryService
    {
        private readonly ICategory _categoryRepository;
        private readonly IValidator<Category> _categoryValidation;
        private readonly IValidator<List<Category>> _categoryValidationList;

        public CategoryService(ICategory categoryRepository, IValidator<Category> categoryValidation, IValidator<List<Category>> categoryValidationList)
        {
            _categoryRepository = categoryRepository;
            _categoryValidation = categoryValidation;
            _categoryValidationList = categoryValidationList;
        }

        public async Task AddCategory(Category category)
        {
            var result = _categoryValidation.Validate(category);

            if (!result.IsValid) // Si la validación falla, no seguimos
            {
                string errores = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                throw new Exception($"Errores de validación:\n{errores}");
            }

            await _categoryRepository.AddCategory(category);
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _categoryRepository.GetCategories();
        }

        public async Task<List<Category>> GetComboBox()
        {
            // Obtiene la lista de categorías
            var categories = await _categoryRepository.GetCategories();

            // Validación de la lista de categorías
            var result = _categoryValidationList.Validate(categories);

            // Si la validación falla, lanza una excepción con los errores
            if (!result.IsValid)
            {
                string errores = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                throw new Exception($"Errores de validación:\n{errores}");
                
            }

            // Si la validación es correcta, devuelve la lista de categorías
            return categories;

        }

    }
}
