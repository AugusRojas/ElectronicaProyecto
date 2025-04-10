using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ValidatorService
{
    public class ProductsXSalesService
    {
        private readonly IProductsXSales PXSRepository;

        public ProductsXSalesService(IProductsXSales PXSRepository)
        {
            this.PXSRepository = PXSRepository;
        }

        public async Task AddPXSAsync(ProductsXSales productsXSales)
        {
            await PXSRepository.AddPXS(productsXSales);
        }
    }
}
