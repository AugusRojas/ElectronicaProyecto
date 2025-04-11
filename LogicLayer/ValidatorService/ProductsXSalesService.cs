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

        public async Task AddPXSAsync(List<ProductsXSales> productsXSales)
        {
            var productsXSalesGroup = productsXSales
                .GroupBy(p => p.idProduct)
                .Select(g => new ProductsXSales
                {
                    idProduct = g.Key,
                    idSale = g.First().idSale, // mismo idSale
                    amount = g.Sum(x => x.amount),
                    discount = g.Sum(x => x.discount), // o promedio, como vos quieras
                    subtotal = g.Sum(x => x.subtotal)
                }).ToList();


            foreach (var pxs in productsXSalesGroup)
            {
                await PXSRepository.AddPXS(productsXSalesGroup);
            }

           
        }
    }
}
