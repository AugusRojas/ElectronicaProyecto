using DataLayer.Interfaces;
using DataLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ValidatorService
{
    public class ProductService
    {
        private readonly IProduct _productRepository;
        private readonly IValidator<Product> _productValidation;

        public ProductService(IProduct productRepository, IValidator<Product> productValidation)
        {
            _productRepository = productRepository;
            _productValidation = productValidation;
        }

        public async Task AddProduct(Product product)
        {
            var result = _productValidation.Validate(product);

            if(!result.IsValid) // Si la validación falla, no seguimos
            {
                string errores = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                throw new Exception($"Errores de validación:\n{errores}");
            }
            await _productRepository.AddProduct(product);
        }

        public async Task DeleteProduct(string name)
        {
            var productDelete = await _productRepository.GetProduct(name);
            var result = _productValidation.Validate(productDelete);
            if (!result.IsValid) // Si la validación falla, no seguimos
            {
                string errores = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                throw new Exception($"Errores de validación:\n{errores}");
            }
            await _productRepository.DeleteProduct(name);

        }

        public async Task ModifyProduct(Product product)
        {
            var producModify = await _productRepository.GetProduct(product.name);
            var result = _productValidation.Validate(producModify);
            if (result.IsValid) // Si la validación falla, no seguimos
            {
                string errores = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                throw new Exception($"Errores de validación:\n{errores}");
            }
            await _productRepository.UpdateProduct(product);
        }

        public async Task<List<object>> GetProductsFilterAsync(string filter, string value)
        {
            return await _productRepository.GetProductsFilter(filter, value);
        }

    }
}
