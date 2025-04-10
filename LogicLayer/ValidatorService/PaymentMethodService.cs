using DataLayer.Interfaces;
using DataLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ValidatorService
{
    public class PaymentMethodService
    {
        private readonly IValidator<PaymentMethod> PmValidation;
        private readonly IPaymentMethods RepositoryPayMethod;
        public PaymentMethodService(IPaymentMethods RepositoryPayMethod, IValidator<PaymentMethod> PmValidation )
        {
            this.RepositoryPayMethod = RepositoryPayMethod;
            this.PmValidation = PmValidation;
        }

        public async Task<List<PaymentMethod>> GetPayMethodsAsync()
        {
            return await RepositoryPayMethod.GetPayMethods();
        }
    }
}
