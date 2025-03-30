using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Interfaces
{
    interface IPaymentMethods
    {
        Task<IEnumerable<PaymentMethod>> GetPayMethods();
        Task<PaymentMethod> GetPayMethod(int id);
        Task AddPayMethod(PaymentMethod payMethod);
        Task UpdatePayMethod(PaymentMethod payMethod);
        Task DeletePayMethod(int id);
    }
}
