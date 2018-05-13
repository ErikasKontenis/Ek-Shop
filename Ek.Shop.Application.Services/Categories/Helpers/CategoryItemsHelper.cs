using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Domain.Categories;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Application.Services.Categories.Helpers
{
    public static class CategoryItemsHelper
    {
        private static IMapper _mapper => AutoMapperFactory.CreateMapper<CategoryItemMapperProfile, ImageMapperProfile>();

        public static List<CategoryItemDto> GetProducts(this Category category)
        {
            var categoryItemsDto = _mapper.Map(category.Products, new List<CategoryItemDto>());

            return categoryItemsDto.ToList();
        }

        public static List<CategoryItemDto> GetSubCategories(this IList<Category> categories)
        {
            if (categories == null)
            {
                return new List<CategoryItemDto>();
            }

            var categoryItemsDto = _mapper.Map(categories, new List<CategoryItemDto>());

            return categoryItemsDto;
        }
    }
}
