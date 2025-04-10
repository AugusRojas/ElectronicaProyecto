using DataLayer.Interfaces;
using DataLayer.Repositories;
using DataLayer.Models;
using DataLayer.Repositories;
using FluentValidation;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ValidatorService
{
    public class SaleService
    {
        private readonly ISale SaleRepository;
        private readonly IValidator<Sale> SaleValidation;
        private readonly IValidator<Product> ProductValidation;
        public SaleService(ISale SaleRepository, IValidator<Sale> SaleValidation, IValidator<Product> ProductValidation)
        {
            this.SaleRepository = SaleRepository;
            this.SaleValidation = SaleValidation;
            this.ProductValidation = ProductValidation;
        }
        public Task<int> AddSale(Sale sale)
        {
            return SaleRepository.AddSale(sale);
        }

        public async Task<List<string>> StockDiscountAsync(List<Product> products)
        {
            var errores = new List<string>();

            foreach (var producto in products)
            {
                var result = await ProductValidation.ValidateAsync(producto);
                if (!result.IsValid)
                {
                    errores.AddRange(result.Errors.Select(e => $"Producto: {producto.name} - {e.ErrorMessage}"));
                }
            }

            if (errores.Any())
                return errores;

            await SaleRepository.StockDiscount(products);
            return new List<string>();
        }


        public async Task<string> GeneratePdfAsync(int idSale)
        {
            var sale = await SaleRepository.GeneratePdf(idSale);

            var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ComprobantesVentas");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var documentoPath = Path.Combine(folderPath, $"Comprobante_{sale.idSale}.pdf");

            var document = new ProofDocument(sale);
            document.GeneratePdf(documentoPath);

            return documentoPath;
        }

        public double TotalProduct(string price, string quantity, string discount)
        {
            double sub = (double.Parse(price) * int.Parse(quantity));
            if (string.IsNullOrEmpty(quantity)) return 0;

            else if (discount == "") return sub;

            else if (int.Parse(discount) > 0)
            {
                double disco = (sub * int.Parse(discount)) / 100;

                return sub - disco;
            }

            else if (int.Parse(discount) == 0) return sub;

            return 0;
        }

        public async Task<string> GetCash(string label_hour, string hour, string label_date)
        {
            var result = await SaleRepository.GetCash(label_hour, hour, label_date);
            if (result == null)
            {
                return "0";
            }
            else
            {
                return result.ToString();
            }
        }
        public async Task<string> GetCard(string label_hour,string hour,string label_date)
        {
            var result = await SaleRepository.GetCard(label_hour, hour, label_date);
            if (result == null)
            {
                return "0";
            }
            else
            {
                return result.ToString();
            }
        }
        public async Task<string> GetTransfer(string label_hour, string hour, string label_date)
        {
            var result = await SaleRepository.GetTransfer(label_hour, hour, label_date);
            if (result == null)
            {
                return "0";
            }
            else
            {
                return result.ToString();
            }
        }
        public async Task<List<object>> GetSummaryProducts(string hourClosgin,string hourOpening ,string date)
        {
            var result = await SaleRepository.GetSummaryProducts(hourClosgin,hourOpening,date);
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }
    }
}
