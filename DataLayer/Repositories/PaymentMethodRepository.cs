using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class PaymentMethodRepository : IPaymentMethods
    {
        public Task AddPayMethod(PaymentMethod payMethod)
        {
            throw new NotImplementedException();
        }

        public Task DeletePayMethod(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethod> GetPayMethod(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentMethod>> GetPayMethods()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePayMethod(PaymentMethod payMethod)
        {
            throw new NotImplementedException();
        }
    }
}
