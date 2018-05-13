using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Services.Infrastructure.CommonHelpers;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Domain.Categories;
using System.Collections.Generic;

namespace Ek.Shop.Application.Services.AutoMappers.Profiles
{
    public class CategoryNavigationMapperProfile : Profile
    {
        public CategoryNavigationMapperProfile()
            : this("CategoryNavigationProfile")
        { }

        protected CategoryNavigationMapperProfile(string profileName)
            : base(profileName)
        {
            CreateMap<Category, CategoryNavigationDto>()
                .ForMember(x => x.Characteristics, m => m.ResolveUsing((x, dst, arg3, context) => CharacteristicsHelper.BuildCharacteristics<CategoryCharacteristic, CategoryCharacteristicTranslation>(x, x.Characteristics, (int)context.Items["WorkingLanguageId"])))
                .ForMember(x => x.Parameters, m => m.MapFrom(x => x.Parameter.ToObject<Dictionary<string, object>>()))
                .ForMember(x => x.Type, m => m.MapFrom(x => x.CategoryType.Code))
                .ForMember(x => x.Url, m => m.MapFrom(x => x.Route.Url));
        }
    }
}
