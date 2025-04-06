using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface IPaymentMethods
    {
        Task<List<string>> GetPayMethods();
        //Task<PaymentMethod> GetPayMethod(int id);
        //Task AddPayMethod(PaymentMethod payMethod);
        //Task UpdatePayMethod(PaymentMethod payMethod);
        //Task DeletePayMethod(int id);
    }
}
