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

        public async Task<string> AddProduct(Product product)
        {
            var result = _productValidation.Validate(product);

            if(!result.IsValid) // Si la validación falla, no seguimos
            {
                string errores = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                return errores;
            }
            await _productRepository.AddProduct(product);
            return "";
        }



        public async Task<string> DeleteProduct(Product product)
        {
            var productDelete = await _productRepository.GetProduct(product.name);
            if(productDelete == null)
            {
                return "El producto no existe";
            }
            else
            {   
                var result = _productValidation.Validate(productDelete);
                if (!result.IsValid) // Si la validación falla, no seguimos
                {
                    string errores = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                    return errores;
                }
                else
                {
                    await _productRepository.DeleteProduct(productDelete);
                    return "";
                }
            }
        }

        public async Task<string> ModifyProduct(Product product)
        {
            var producModify = await _productRepository.GetProduct(product.name);
            if (producModify == null)
            {
                return "El Producto no existe";
            }
            else
            {
                var result = _productValidation.Validate(producModify);
                if (!result.IsValid) // Si la validación falla, no seguimos
                {
                    string errores = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
                    return errores;
                }
                else
                {
                    await _productRepository.UpdateProduct(product);
                    return "";
                }
            } 
        }
        public async Task<List<object>> GetDataGridView()
        {
            return await _productRepository.GetDataGridView();
        }
        public async Task<List<object>> GetAllProductsFilters(string name)
        {
            return await _productRepository.GetAllProductsFilters(name);
        }
    }
}
