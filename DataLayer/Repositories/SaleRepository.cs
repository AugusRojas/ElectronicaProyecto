using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class SaleRepository : ISale
    {
        private readonly Db_Context _context;

        public SaleRepository(Db_Context context)
        {
            _context = context;
        }
        //trae el total de efectivo
        public async Task<string> GetCash()
        {
            decimal result = await _context.Sale
                .Where(s => s.idPaymentMethod == 1)
                .SumAsync(s => s.totalAmount);
            if (result == 0)
            {
                return "No hay productos";
            }
            else
            {
                return result.ToString();
            }
        }

        //trae el total de tarjeta
        public async Task<string> GetCard()
        {
            decimal result = await _context.Sale
                .Where(s=>s.idPaymentMethod == 2)
                .SumAsync(s => s.totalAmount);
            if (result == 0)
            {
                return "No hay productos";
            }
            else
            {
                return result.ToString();
            }
        }
        //trae el total de trasnferencias
        public async Task<string> GetTransfer()
        {
            var result = await _context.Sale
                .Where(s => s.idPaymentMethod == 3)
                .SumAsync(s => s.totalAmount);
            if (result == 0)
            {
                return "No hay productos";
            }
            else
            {
                return result.ToString();
            }
        }
        public async Task<List<object>> GetSummaryProducts()
        {
            var resultGet = await _context.ProductsXSales
                               .Include(s=>s.product)
                               .Include(p => p.sale)
                                    .ThenInclude(p=>p.PaymentMethod)
                               .Select(t => new
                               {
                                   t.product.idProduct,
                                   t.sale.idSale,
                                   t.product.name,
                                   t.amount,
                                   t.subtotal,
                                   t.discount,
                                   t.sale.date,
                                   t.sale.hour,
                                   t.sale.PaymentMethod.namePaymentMethod
                               }).ToListAsync();

            if (resultGet == null)
            {
                return null;
            }
            else
            {
                List<object> result = resultGet.Cast<object>().ToList();
                return result.Cast<object>().ToList();
            }
        }
        public Task AddSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSale(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetSale(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sale>> GetSales()
        {
            throw new NotImplementedException();
        }

        public Task UpdateSale(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
