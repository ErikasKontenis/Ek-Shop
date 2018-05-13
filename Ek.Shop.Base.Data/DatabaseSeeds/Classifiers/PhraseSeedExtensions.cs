using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Languages;
using Ek.Shop.Domain.Phrases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Classifiers
{
    public static class PhraseSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<Phrase>()
            {
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.Citadele.Code,
                    Value = PaymentMethodTypes.Citadele.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.DanskeBank.Code,
                    Value = PaymentMethodTypes.DanskeBank.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.Dnb.Code,
                    Value = PaymentMethodTypes.Dnb.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.Nordea.Code,
                    Value = PaymentMethodTypes.Nordea.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.Seb.Code,
                    Value = PaymentMethodTypes.Seb.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.SiauliaiBank.Code,
                    Value = PaymentMethodTypes.SiauliaiBank.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.Swedbank.Code,
                    Value = PaymentMethodTypes.Swedbank.Name
                },
                
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = CategoryTypes.Footer,
                    Value = "Footer"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = CategoryTypes.Left,
                    Value = "Left"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = CategoryTypes.Product,
                    Value = "Product"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = CategoryTypes.Top,
                    Value = "Top"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = CategoryTypes.TopUser,
                    Value = "Top User Section"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = AngularComponents.HomeComponent,
                    Value = "Home Category"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = AngularComponents.ProductComponent,
                    Value = "Product"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = AngularComponents.SubCategoryComponent,
                    Value = "Sub Category"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = AngularComponents.TextCategoryComponent,
                    Value = "Custom Text Based Category"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = ShippingMethods.Courier,
                    Value = "Atsiėmimas iš kurjerio"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = ShippingMethods.Shop,
                    Value = "Atsiėmimas parduotuvėje"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethods.Banklink,
                    Value = "El. bankininkystė"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethods.Cash,
                    Value = "Grynais"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.Citadele.Code,
                    Value = PaymentMethodTypes.Citadele.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.DanskeBank.Code,
                    Value = PaymentMethodTypes.DanskeBank.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.Dnb.Code,
                    Value = PaymentMethodTypes.Dnb.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.Nordea.Code,
                    Value = PaymentMethodTypes.Nordea.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.Seb.Code,
                    Value = PaymentMethodTypes.Seb.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.SiauliaiBank.Code,
                    Value = PaymentMethodTypes.SiauliaiBank.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = PaymentMethodTypes.Swedbank.Code,
                    Value = PaymentMethodTypes.Swedbank.Name
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = OrderStatuses.Canceled,
                    Value = "Atšauktas"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = OrderStatuses.Confirmed,
                    Value = "Patvirtintas"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = OrderStatuses.Delivered,
                    Value = "Pristatytas"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = OrderStatuses.Finished,
                    Value = "Pabaigtas"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = OrderStatuses.Shipping,
                    Value = "Siunčiamas"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.Lithuanian).Id,
                    Code = OrderStatuses.Unconfirmed,
                    Value = "Nepatvirtintas"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = OrderStatuses.Canceled,
                    Value = "Canceled"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = OrderStatuses.Confirmed,
                    Value = "Confirmed"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = OrderStatuses.Delivered,
                    Value = "Delivered"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = OrderStatuses.Finished,
                    Value = "Finished"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = OrderStatuses.Shipping,
                    Value = "Shipping"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = OrderStatuses.Unconfirmed,
                    Value = "Unconfirmed"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = ShippingMethods.Courier,
                    Value = "Withdrawal from courier"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = ShippingMethods.Shop,
                    Value = "Withdrawal from shop"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = PaymentMethods.Banklink,
                    Value = "Bank-link"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = PaymentMethods.Cash,
                    Value = "Cash"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = PaymentMethodTypes.Citadele.Code,
                    Value = "Citadele"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = PaymentMethodTypes.DanskeBank.Code,
                    Value = "Dasnke bank"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = PaymentMethodTypes.Dnb.Code,
                    Value = "Dnb"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = PaymentMethodTypes.Nordea.Code,
                    Value = "Nordea"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = PaymentMethodTypes.Seb.Code,
                    Value = "Seb"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = PaymentMethodTypes.SiauliaiBank.Code,
                    Value = "Siauliai bank"
                },
                new Phrase
                {
                    LanguageId = dbContext.Set<Language>().FirstOrDefault(o => o.Code == Languages.English).Id,
                    Code = PaymentMethodTypes.Swedbank.Code,
                    Value = "Swedbank"
                },
            });
        }
    }
}
