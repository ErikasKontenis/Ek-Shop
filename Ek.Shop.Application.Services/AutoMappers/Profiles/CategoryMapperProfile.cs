using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Services.Categories.Helpers;
using Ek.Shop.Application.Services.Infrastructure.CommonHelpers;
using Ek.Shop.Application.Services.InputFieldsets.Helpers;
using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Categories;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Application.Services.AutoMappers.Profiles
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
            : this("CategoryMapperProfile")
        { }

        protected CategoryMapperProfile(string profileName)
            : base(profileName)
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(x => x.AngularComponentCode, m => m.ResolveUsing(x => x.Route.AngularComponent?.Code))
                .ForMember(x => x.CategoryTypeCode, m => m.ResolveUsing(x => x.CategoryType?.Code))
                .ForMember(x => x.Characteristics, m => m.ResolveUsing((x, dst, arg3, context) => CharacteristicsHelper.BuildCharacteristics<CategoryCharacteristic, CategoryCharacteristicTranslation>(x, x.Characteristics, (int)context.Items["WorkingLanguageId"])))
                .ForMember(x => x.Description, m => m.MapFrom(x => x.Route.Description))
                .ForMember(x => x.Fieldsets, m => m.ResolveUsing((x, dst, arg3, context) => InputFieldsetsHelper.BuildInputFieldsets(x.Fieldsets.Concat(x.Route.AngularComponent.InputFieldsets).ToList(), (int)context.Items["WorkingLanguageId"])))
                .ForMember(x => x.InputFormId, m => m.MapFrom(x => x.Route.InputFormId))
                .ForMember(x => x.Navigations, m => m.ResolveUsing((x, dst, arg3, context) => x.GetCategoryNavigations((int)context.Items["WorkingLanguageId"])))
                .ForMember(x => x.Parameters, m => m.MapFrom(x => x.Parameter.ToObject<Dictionary<string, object>>()))
                .ForMember(x => x.SubCategories, m => m.MapFrom(x => x.Children.ToPagedList()))
                .ForMember(x => x.Title, m => m.MapFrom(x => x.Route.Title))
                .ForMember(x => x.Url, m => m.MapFrom(x => x.Route.Url))
                // The Products is supposed to be set always from the independent service
                .ForMember(x => x.Products, m => m.Ignore())
                .ReverseMap()
                .ForMember(x => x.CategoryType, o => o.Ignore())
                .ForMember(x => x.Characteristics, o => o.Ignore())
                .ForMember(x => x.Fieldsets, o => o.Ignore())
                .ForMember(x => x.Children, o => o.Ignore())
                .ForMember(x => x.Images, o => o.Ignore())
                .ForMember(x => x.Parent, o => o.Ignore())
                .BeforeMap((x, d) => x.Title = string.IsNullOrEmpty(x.Title) ? x.Characteristics.GetValue(CharacteristicCodes.Name) : x.Title)
                .BeforeMap((x, d) => x.Url = x.Url == null ? x.Title.ToUrlFriendly() ?? x.Characteristics.GetValue(CharacteristicCodes.Name).ToUrlFriendly() : x.Url);

            CreateMissingTypeMaps = true;
        }
    }
}
