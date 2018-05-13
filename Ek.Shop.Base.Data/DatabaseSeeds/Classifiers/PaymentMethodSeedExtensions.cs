using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.PaymentMethods;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Classifiers
{
    public static class PaymentMethodSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<PaymentMethod>()
            {
                new PaymentMethod
                {
                    Code = PaymentMethods.Banklink,
                    PaymentMethodTypes = new List<PaymentMethodType>()
                    {
                        new PaymentMethodType()
                        {
                            Code = PaymentMethodTypes.Citadele.Code
                        },
                        new PaymentMethodType()
                        {
                            Code = PaymentMethodTypes.DanskeBank.Code
                        },
                        new PaymentMethodType()
                        {
                            Code = PaymentMethodTypes.Dnb.Code
                        },
                        new PaymentMethodType()
                        {
                            Code = PaymentMethodTypes.Nordea.Code
                        },
                        new PaymentMethodType()
                        {
                            Code = PaymentMethodTypes.Seb.Code
                        },
                        new PaymentMethodType()
                        {
                            Code = PaymentMethodTypes.SiauliaiBank.Code
                        },
                        new PaymentMethodType()
                        {
                            Code = PaymentMethodTypes.Swedbank.Code
                        },
                    }
                },
                new PaymentMethod
                {
                    Code = PaymentMethods.Cash
                },
            });
        }
    }
}
