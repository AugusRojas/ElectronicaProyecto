using DataLayer.Interfaces;
using DataLayer.Models;
using DocumentFormat.OpenXml.Drawing;
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
        public async Task<string> GetCash(string label_hour, string hour, string label_date)
        {
            if (string.IsNullOrEmpty(label_hour) || string.IsNullOrEmpty(hour) || string.IsNullOrEmpty(label_date))
                return "0";

            if (!DateTime.TryParse(hour, out var startHour) || !DateTime.TryParse(label_hour, out var endHour))
                return "0";

            var ventas = await _context.Sale
                .Where(s => s.idPaymentMethod == 2 && s.date == label_date)
                .ToListAsync(); // 🔥 Acá traés todo a memoria, y después filtrás

            var resultado = ventas
                .Where(s => DateTime.TryParse(s.hour, out var h) && h >= startHour && h <= endHour)
                .Sum(s => s.totalAmount);

            return resultado == 0 ? "0" : resultado.ToString();
        }

        //trae el total de tarjeta
        public async Task<string> GetCard(string label_hour, string hour, string label_date)
        {
            if (string.IsNullOrEmpty(label_hour) || string.IsNullOrEmpty(hour) || string.IsNullOrEmpty(label_date))
                return "0";

            if (!DateTime.TryParse(hour, out var startHour) || !DateTime.TryParse(label_hour, out var endHour))
                return "0";

            var ventas = await _context.Sale
                .Where(s => s.idPaymentMethod == 1 && s.date == label_date)
                .ToListAsync(); // 🔥 Acá traés todo a memoria, y después filtrás

            var resultado = ventas
                .Where(s => DateTime.TryParse(s.hour, out var h) && h >= startHour && h <= endHour)
                .Sum(s => s.totalAmount);

            return resultado == 0 ? "0" : resultado.ToString();
        }
        //trae el total de trasnferencias
        public async Task<string> GetTransfer(string label_hour, string hour, string label_date)
        {
            if (string.IsNullOrEmpty(label_hour) || string.IsNullOrEmpty(hour) || string.IsNullOrEmpty(label_date))
                return "0";

            if (!DateTime.TryParse(hour, out var startHour) || !DateTime.TryParse(label_hour, out var endHour))
                return "0";

            var ventas = await _context.Sale
                .Where(s => s.idPaymentMethod == 3 && s.date == label_date)
                .ToListAsync(); // 🔥 Acá traés todo a memoria, y después filtrás

            var resultado = ventas
                .Where(s => DateTime.TryParse(s.hour, out var h) && h >= startHour && h <= endHour)
                .Sum(s => s.totalAmount);

            return resultado == 0 ? "0" : resultado.ToString();
        }


        public async Task<List<object>> GetSummaryProducts(string hourClosing, string hourOpening, string date)
        {
            if (!DateTime.TryParse(hourOpening, out var opening) || !DateTime.TryParse(hourClosing, out var closing))
                return [];

            var resultGet = await _context.ProductsXSales
                .Include(s => s.product)
                .Include(p => p.sale)
                    .ThenInclude(p => p.PaymentMethod)
                .Where(s => s.sale.date == date && !string.IsNullOrEmpty(s.sale.hour))
                .ToListAsync();

            // Filtro por hora en memoria
            var filtered = resultGet
                .Where(s =>
                    DateTime.TryParse(s.sale.hour, out var saleHour) &&
                    saleHour >= opening &&
                    saleHour <= closing
                )
                .ToList();

            // Agrupamos por ID de producto para no repetir productos iguales
            var grouped = filtered
                .GroupBy(t => t.product.idProduct)
                .Select(g => new
                {
                    idProduct = g.Key,
                    idSale = g.First().sale.idSale,
                    name = g.First().product.name,
                    amount = g.Sum(x => x.amount),
                    price = g.First().product.price,
                    subtotal = g.Sum(x => x.amount * x.product.price), // Aseguramos cálculo
                    discount = g.First().discount,
                    date = g.Max(x => x.sale.date),
                    hour = g.Max(x => x.sale.hour),
                    paymentMethod = g.First().sale.PaymentMethod.namePaymentMethod
                })
                .Cast<object>()
                .ToList();

            return grouped;
        }


        public async Task<int> AddSale(Sale sale)
        {
            await _context.Sale.AddAsync(sale);
            await _context.SaveChangesAsync();
            return sale.idSale;
        }
        
        public async Task<Sale> GeneratePdf(int idSale)
        {
            return await _context.Sale
                .Include(s => s.PaymentMethod)
                .Include(s => s.ProductsXSales)
                    .ThenInclude(pxs => pxs.product)
                .FirstOrDefaultAsync(s => s.idSale == idSale);
        }

        public async Task StockDiscount(List<Product> products)
        {
             foreach(var pr in products)
             {
                var product = await _context.Product.FirstOrDefaultAsync(p => p.idProduct == pr.idProduct);

                product.stock = pr.stock;
             }

            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Sale>> GetSales()
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetSale(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSale(int id)
        {
            throw new NotImplementedException();
        }
    }
}
