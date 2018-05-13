using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Services.Infrastructure.CommonHelpers;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Products;

namespace Ek.Shop.Application.Services.AutoMappers.Profiles
{
    public class CategoryItemMapperProfile : Profile
    {
        public CategoryItemMapperProfile()
            : this("CategoryItemMapperProfile")
        { }

        protected CategoryItemMapperProfile(string profileName)
            : base(profileName)
        {
            // TODO: fix workingLanguageId
            CreateMap<Category, CategoryItemDto>()
                .ForMember(x => x.Characteristics, m => m.MapFrom(x => CharacteristicsHelper.BuildCharacteristics<CategoryCharacteristic, CategoryCharacteristicTranslation>(x, x.Characteristics, 1)))
                .ForMember(x => x.Url, m => m.MapFrom(x => x.Route.Url));

            CreateMap<Product, CategoryItemDto>()
                .ForMember(x => x.Characteristics, m => m.MapFrom(x => CharacteristicsHelper.BuildCharacteristics<ProductCharacteristic, ProductCharacteristicTranslation>(x, x.Characteristics, 1)))
                .ForMember(x => x.DetailsCount, m => m.MapFrom(x => x.ProductDetails.Count))
                .ForMember(x => x.Url, m => m.MapFrom(x => x.Route.Url));
        }
    }
}
