using DataLayer.Interfaces;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ValidatorService
{
    public class SaleService
    {
        private readonly ISale _SaleRepository;

        public SaleService(ISale SaleRepository)
        {
            _SaleRepository = SaleRepository;
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

        public async Task<string> GetCash()
        {
            var result = await _SaleRepository.GetCash();
            if (result == null)
            {
                return "No hay productos";
            }
            else
            {
                return result.ToString();
            }
        }
        public async Task<string> GetCard()
        {
            var result = await _SaleRepository.GetCard();
            if (result == null)
            {
                return "No hay productos";
            }
            else
            {
                return result.ToString();
            }
        }
        public async Task<string> GetTransfer()
        {
            var result = await _SaleRepository.GetTransfer();
            if (result == null)
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
            var result = await _SaleRepository.GetSummaryProducts();
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
