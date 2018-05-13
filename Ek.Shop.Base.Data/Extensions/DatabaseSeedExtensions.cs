using Ek.Shop.Base.Data.DatabaseSeeds.Admin;
using Ek.Shop.Base.Data.DatabaseSeeds.Admin.Components;
using Ek.Shop.Base.Data.DatabaseSeeds.Classifiers;
using Ek.Shop.Base.Data.DatabaseSeeds.Client;
using Ek.Shop.Base.Data.DatabaseSeeds.Client.Components;
using Ek.Shop.Base.Data.DatabaseSeeds.Locales;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain;
using Ek.Shop.Domain.AngularComponents;
using Ek.Shop.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Base.Data.Extensions
{
    public static class DatabaseSeedExtensions
    {
        public static T Seed<T>(this T dbContext)
            where T : DbContext
        {
            // Perform seed operations
            ClassifierSeeds(dbContext);
            LucidSeeds(dbContext);
            BasicAdminSeeds(dbContext);
            
            return dbContext;
        }

        private static void BasicAdminSeeds<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            AdminDashboardSeedExtensions.Seed(dbContext);
            AdminSubCategorySeedExtensions.Seed(dbContext);
            AdminLoginSeedExtensions.Seed(dbContext);
            AdminLogoutSeedExtensions.Seed(dbContext);

            AdminCategorySeedExtensions.Seed(dbContext);
            AdminProductSeedExtensions.Seed(dbContext);

            AdminOrdersSeedExtensions.Seed(dbContext);

        }

        private static void LucidSeeds<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            ClientHomeSeedExtensions.Seed(dbContext);
            ClientSub1CategorySeedExtensions.Seed(dbContext);
            ClientSub2CategorySeedExtensions.Seed(dbContext);
            ClientCategorySeedExtensions.Seed(dbContext);
            ClientProductSeedExtensions.Seed(dbContext);
            ClientUserSeedExtensions.Seed(dbContext);
        }

        private static void ClassifierSeeds<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            InputFormSeedExtensions.Seed(dbContext);
            ProductDetailTypeSeedExtensions.Seed(dbContext);
            ImageSizeTypeSeedExtensions.Seed(dbContext);

            LanguageSeedExtensions.Seed(dbContext);
            EnglishLanguageResourceSeedExtensions.Seed(dbContext);

            OrderStatusSeedExtensions.Seed(dbContext);
            PaymentMethodSeedExtensions.Seed(dbContext);
            CharacteristicSeedExtensions.Seed(dbContext);

            //AddSeeds(dbContext, new List<TransactionBanklink>()
            //    {
            //        new TransactionBanklink
            //        {
            //            Id = 1,
            //            Code = TransactionBanklinks.Citadele.Code,
            //            Name = TransactionBanklinks.Citadele.Name
            //        },
            //        new TransactionBanklink
            //        {
            //            Id = 2,
            //            Code = TransactionBanklinks.DanskeBank.Code,
            //            Name = TransactionBanklinks.DanskeBank.Name
            //        },
            //        new TransactionBanklink
            //        {
            //            Id = 3,
            //            Code = TransactionBanklinks.Dnb.Code,
            //            Name = TransactionBanklinks.Dnb.Name
            //        },
            //        new TransactionBanklink
            //        {
            //            Id = 4,
            //            Code = TransactionBanklinks.Nordea.Code,
            //            Name = TransactionBanklinks.Nordea.Name
            //        },
            //        new TransactionBanklink
            //        {
            //            Id = 5,
            //            Code = TransactionBanklinks.Seb.Code,
            //            Name = TransactionBanklinks.Seb.Name
            //        },
            //        new TransactionBanklink
            //        {
            //            Id = 6,
            //            Code = TransactionBanklinks.SiauliaiBank.Code,
            //            Name = TransactionBanklinks.SiauliaiBank.Name
            //        },
            //        new TransactionBanklink
            //        {
            //            Id = 7,
            //            Code = TransactionBanklinks.Swedbank.Code,
            //            Name = TransactionBanklinks.Swedbank.Name
            //        }
            //    });

            PhraseSeedExtensions.Seed(dbContext);
            CategoryTypeSeedExtensions.Seed(dbContext);
            ShippingMethodSeedExtensions.Seed(dbContext);
            SystemSettingsSeedExtensions.Seed(dbContext);

            ListCategoryAdminComponentSeedExtensions.Seed(dbContext);
            ListOrderAdminComponentSeedExtensions.Seed(dbContext);
            EditCategoryAdminComponentSeedExtensions.Seed(dbContext);
            EditOrderAdminComponentSeedExtensions.Seed(dbContext);
            EditProductAdminComponentSeedExtensions.Seed(dbContext);
            ListProductAdminComponentSeedExtensions.Seed(dbContext);

            BasketComponentSeedExtensions.Seed(dbContext);
            HomeComponentSeedExtensions.Seed(dbContext);
            OrderComponentSeedExtensions.Seed(dbContext);
            LoginComponentSeedExtensions.Seed(dbContext);
            LogoutComponentSeedExtensions.Seed(dbContext);
            RegistrationComponentSeedExtensions.Seed(dbContext);
            ProductCategoryComponentSeedExtensions.Seed(dbContext);
            ProductComponentSeedExtensions.Seed(dbContext);
            ProfileComponentSeedExtensions.Seed(dbContext);

            AddSeeds(dbContext, new List<AngularComponent>()
            {
                new AngularComponent
                {
                    Code = AngularComponents.SubCategoryComponent
                },
                new AngularComponent
                {
                    Code = AngularComponents.TextCategoryComponent
                },
                new AngularComponent
                {
                    Code = AngularComponents.DashboardAdminComponent
                },
                new AngularComponent
                {
                    Code = AngularComponents.AddCategoryAdminComponent
                }
            });

            AddIdentitySeeds(dbContext, new List<Domain.Identities.IdentityRole>()
            {
                new Domain.Identities.IdentityRole { Name= "Admin", NormalizedName = "ADMIN", Description = "Full rights role"},
                new Domain.Identities.IdentityRole { Name= "User", NormalizedName = "USER", Description = "Limited rights role"}
            });

            AddIdentitySeeds(dbContext, new List<User>()
            {
                new User()
                {
                    Email = "123@123.com",
                    UserName = "123@123.com",
                    NormalizedEmail = "123@123.COM",
                    NormalizedUserName = "123@123.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEPCEiugkYJS3ONAG7qtLqvYKPyOjgGu6aEK72P0moHKaT29tSIFYD9eqIjhXe8+Jig==", // 123123
                    SecurityStamp = "93ea9b29-9eee-43b2-9b24-c3674f793eb3",
                    Name = "Erikas",
                    LastName = "Kontenis"
                }
            });

            AddIdentitySeeds(dbContext, new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                }
            });
        }

        public static void AddSeeds<TDbContet, TSeed>(TDbContet dbContext, List<TSeed> seeds)
            where TDbContet : DbContext
            where TSeed : Entity
        {
            foreach (var seed in seeds)
            {
                if (!dbContext.Set<TSeed>().Any(o => o.Id == seed.Id))
                {
                    dbContext.Add(seed);
                }
            }

            dbContext.SaveChanges();
        }

        public static void AddClassifierSeeds<TDbContet, TSeed>(TDbContet dbContext, List<TSeed> seeds)
            where TDbContet : DbContext
            where TSeed : Classifier
        {
            foreach (var seed in seeds)
            {
                if (!dbContext.Set<TSeed>().Any(o => o.Code == seed.Code))
                {
                    dbContext.Add(seed);
                }
            }

            dbContext.SaveChanges();
        }

        public static void SeedUsers<TDbContet, TSeed>(TDbContet dbContext, List<TSeed> seeds)
            where TDbContet : DbContext
            where TSeed : IdentityUser<int>
        {
            var isAnyEntry = dbContext.Set<TSeed>().Any();
            if (!isAnyEntry)
            {
                dbContext.AddRange(seeds);
                dbContext.SaveChanges();
            }
        }

        public static void AddIdentitySeeds<TDbContet, TSeed>(TDbContet dbContext, List<TSeed> seeds)
            where TDbContet : DbContext
            where TSeed : class
        {
            var isAnyEntry = dbContext.Set<TSeed>().Any();
            if (!isAnyEntry)
            {
                dbContext.AddRange(seeds);
                dbContext.SaveChanges();
            }
        }
    }
}
