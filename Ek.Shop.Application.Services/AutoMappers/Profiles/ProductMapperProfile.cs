using AutoMapper;
using Ek.Shop.Application.Products;
using Ek.Shop.Application.Services.Categories.Helpers;
using Ek.Shop.Application.Services.Infrastructure.CommonHelpers;
using Ek.Shop.Application.Services.InputFieldsets.Helpers;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.InputFieldsets;
using Ek.Shop.Domain.Products;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Application.Services.AutoMappers.Profiles
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
            : this("ProductMapperProfile")
        { }

        protected ProductMapperProfile(string profileName)
            : base(profileName)
        {
            // TODO: fix workingLanguageId
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.AngularComponentCode, m => m.ResolveUsing(x => x.Route?.AngularComponent?.Code))
                .ForMember(x => x.Description, m => m.MapFrom(x => x.Route.Description))
                .ForMember(x => x.Navigations, m => m.ResolveUsing((x, dst, arg3, context) => x.Category.GetCategoryNavigations((int)context.Items["WorkingLanguageId"])))
                .ForMember(x => x.ProductDetails, m => m.ResolveUsing((x, dst, arg3, context) => x.ProductDetails.Select(o => new ProductDetailDto()
                {
                    Characteristics = CharacteristicsHelper.BuildCharacteristics<ProductDetailCharacteristic, ProductDetailCharacteristicTranslation>(o, o.Characteristics, (int)context.Items["WorkingLanguageId"]),
                    Id = o.Id,
                    IsOutOfStock = o.IsOutOfStock,
                    Type = o.ProductDetailType.Code,
                    Value = o.Value
                }).ToList()))
                .ForMember(x => x.Characteristics, m => m.ResolveUsing((x, dst, arg3, context) => CharacteristicsHelper.BuildCharacteristics<ProductCharacteristic, ProductCharacteristicTranslation>(x, x.Characteristics, (int)context.Items["WorkingLanguageId"])))
                .ForMember(x => x.Fieldsets, m => m.ResolveUsing((x, dst, arg3, context) => InputFieldsetsHelper.BuildInputFieldsets(x?.Fieldsets?.Concat(x?.Route?.AngularComponent?.InputFieldsets ?? new List<InputFieldset>())?.ToList(), (int)context.Items["WorkingLanguageId"])))
                .ForMember(x => x.Rating, m => m.MapFrom(x => x.ProductRatings.Sum(o => o.Rate)))
                .ForMember(x => x.SimilarProducts, m => m.Ignore())
                //.ForMember(x => x.SimilarProducts, m => m.MapFrom(x => x.SimilarProducts.ToList()))
                .ForMember(x => x.Title, m => m.MapFrom(x => x.Route.Title))
                .ForMember(x => x.Url, m => m.MapFrom(x => x.Route.Url))
                .ReverseMap()
                .ForMember(x => x.Characteristics, o => o.Ignore())
                .ForMember(x => x.Fieldsets, o => o.Ignore())
                .ForMember(x => x.Category, o => o.Ignore())
                .ForMember(x => x.Images, o => o.Ignore())
                .BeforeMap((x, d) => x.Title = string.IsNullOrEmpty(x.Title) ? x.Characteristics.GetValue(CharacteristicCodes.Name) : x.Title)
                .BeforeMap((x, d) => x.Url = x.Url == null ? x.Title.ToUrlFriendly() ?? x.Characteristics.GetValue(CharacteristicCodes.Name).ToUrlFriendly() : x.Url);

            CreateMissingTypeMaps = true;
        }
    }
}
