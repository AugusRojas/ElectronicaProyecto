using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class PaymentMethodRepository : IPaymentMethods
    {
        private readonly Db_Context context;

        public PaymentMethodRepository(Db_Context context)
        {
            this.context = context;
        }

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

        public Task<List<PaymentMethod>> GetPayMethods()
        {
            return context.PaymentMethod.ToListAsync();
        }

        public Task UpdatePayMethod(PaymentMethod payMethod)
        {
            throw new NotImplementedException();
        }
    }
}
