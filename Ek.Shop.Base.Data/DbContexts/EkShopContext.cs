using Ek.Shop.Base.Data.Configurations;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Domain.AngularComponents;
using Ek.Shop.Domain.Baskets;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Characteristics;
using Ek.Shop.Domain.Images;
using Ek.Shop.Domain.InputFields;
using Ek.Shop.Domain.InputFieldsets;
using Ek.Shop.Domain.InputForms;
using Ek.Shop.Domain.Languages;
using Ek.Shop.Domain.Orders;
using Ek.Shop.Domain.PaymentMethods;
using Ek.Shop.Domain.Phrases;
using Ek.Shop.Domain.Products;
using Ek.Shop.Domain.Routes;
using Ek.Shop.Domain.SystemSettings;
using Ek.Shop.Domain.Transactions;
using Ek.Shop.Domain.Users;
using Ek.Shop.Domain.Vouchers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ek.Shop.Base.Data.DbContexts
{
    public partial class EkShopContext : IdentityDbContext<User, Domain.Identities.IdentityRole, int>
    {
        public EkShopContext()
        { }

        public virtual DbSet<AngularComponent> AngularComponents { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<BasketItem> BasketItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryCharacteristic> CategoryCharacteristics { get; set; }
        public virtual DbSet<CategoryCharacteristicTranslation> CategoryCharacteristicTranslations { get; set; }
        public virtual DbSet<CategoryType> CategoryTypes { get; set; }
        public virtual DbSet<Characteristic> Characteristics { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ImageCharacteristic> ImageCharacteristics { get; set; }
        public virtual DbSet<ImageCharacteristicTranslation> ImageCharacteristicTranslations { get; set; }
        public virtual DbSet<ImageSizeType> ImageSizeTypes { get; set; }
        public virtual DbSet<InputField> InputFields { get; set; }
        public virtual DbSet<InputFieldCharacteristic> InputFieldCharacteristics { get; set; }
        public virtual DbSet<InputFieldCharacteristicTranslation> InputFieldCharacteristicTranslations { get; set; }
        public virtual DbSet<InputFieldset> InputFieldsets { get; set; }
        public virtual DbSet<InputFieldsetCharacteristic> InputFieldsetCharacteristics { get; set; }
        public virtual DbSet<InputFieldsetCharacteristicTranslation> InputFieldsetCharacteristicTranslations { get; set; }
        public virtual DbSet<InputForm> InputForms { get; set; }
        public virtual DbSet<InputFormOption> InputFormOptions { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LocaleLanguageResource> LocaleLanguageResources { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderCharacteristic> OrderCharacteristics { get; set; }
        public virtual DbSet<OrderCharacteristicTranslation> OrderCharacteristicTranslations { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<PaymentMethodType> PaymentMethodTypes { get; set; }
        public virtual DbSet<Phrase> Phrases { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCharacteristic> ProductCharacteristics { get; set; }
        public virtual DbSet<ProductCharacteristicTranslation> ProductCharacteristicTranslations { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<ProductDetailCharacteristic> ProductDetailCharacteristics { get; set; }
        public virtual DbSet<ProductDetailCharacteristicTranslation> ProductDetailCharacteristicTranslations { get; set; }
        public virtual DbSet<ProductDetailType> ProductDetailTypes { get; set; }
        public virtual DbSet<ProductRating> ProductRatings { get; set; }
        public virtual DbSet<ProductReview> ProductReviews { get; set; }
        public virtual DbSet<ProductSpecificationAttributeOption> ProductSpecificationAttributeOptions { get; set; }
        public virtual DbSet<ProductSpecificationAttribute> ProductSpecificationAttributes { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<ShippingMethod> ShippingMethods { get; set; }
        public virtual DbSet<SystemSetting> SystemSettings { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;userid=root;password=;database=EkShop;CharSet=utf8;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ModelBuilderExtensions.PluralizingTableNameConvention(modelBuilder);

            #region EF Core Identity
            modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserTokens");

                entity.Property(o => o.LoginProvider).HasMaxLength(64);
                entity.Property(o => o.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(r => r.NormalizedUserName).HasMaxLength(255);
            });

            modelBuilder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            modelBuilder.Entity<Domain.Identities.IdentityRole>(entity =>
            {
                entity.Property(r => r.NormalizedName).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(r => r.NormalizedUserName).HasMaxLength(255);
            });

            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.Property(r => r.LoginProvider).HasMaxLength(64);
                entity.Property(r => r.ProviderKey).HasMaxLength(64);
            });
            #endregion

            modelBuilder.ApplyConfiguration(new AngularComponentConfiguration());
            modelBuilder.ApplyConfiguration(new BasketConfiguration());
            modelBuilder.ApplyConfiguration(new BasketItemConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryCharacteristicConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryCharacteristicTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CharacteristicConfiguration());
            modelBuilder.ApplyConfiguration(new ImageCharacteristicConfiguration());
            modelBuilder.ApplyConfiguration(new ImageCharacteristicTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new ImageSizeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InputFieldCharacteristicConfiguration());
            modelBuilder.ApplyConfiguration(new InputFieldCharacteristicTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new InputFieldConfiguration());
            modelBuilder.ApplyConfiguration(new InputFieldsetCharacteristicConfiguration());
            modelBuilder.ApplyConfiguration(new InputFieldsetCharacteristicTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new InputFieldsetConfiguration());
            modelBuilder.ApplyConfiguration(new InputFormConfiguration());
            modelBuilder.ApplyConfiguration(new InputFormOptionConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new LocaleLanguageResourceConfiguration());
            modelBuilder.ApplyConfiguration(new OrderCharacteristicConfiguration());
            modelBuilder.ApplyConfiguration(new OrderCharacteristicTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PhraseConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCharacteristicConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCharacteristicTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailCharacteristicConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailCharacteristicTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductRatingConfiguration());
            modelBuilder.ApplyConfiguration(new ProductReviewConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSpecificationAttributeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSpecificationAttributeOptionConfiguration());
            modelBuilder.ApplyConfiguration(new RouteConfiguration());
            modelBuilder.ApplyConfiguration(new ShippingMethodConfiguration());
            modelBuilder.ApplyConfiguration(new SystemSettingConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VoucherConfiguration());
        }
    }
}