using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Application.Extensions;
using Ek.Shop.Application.Services.AutoMappers;
using Ek.Shop.Application.Services.AutoMappers.Profiles;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Domain.Categories;
using Force.DeepCloner;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Application.Services.Categories.Helpers
{
    public static class CategoryNavigationsHelper
    {
        private static IMapper _mapper => AutoMapperFactory.CreateMapper<CategoryBreadcrumbMapperProfile>();

        public static List<CategoryNavigationDto> GetCategoryNavigations(this Category category, int languageId)
        {
            var categoryNavigationsDto = _mapper.Map(category.BuildCategoryNavigations(), new List<CategoryNavigationDto>(), opt => opt.Items["WorkingLanguageId"] = languageId);

            return categoryNavigationsDto;
        }

        public static string GetCategoryChainedNavigation(this Category category)
        {
            return category?.BuildCategoryNavigations()?.Last()?.Route?.Url;
        }

        public static List<Category> BuildCategoryNavigations(this Category category)
        {
            var buildedCategories = new List<Category>();
            if (category == null)
            {
                return buildedCategories;
            }

            category.Children = category.Children ?? new List<Category>();
            var categoryNodes = category.DeepClone().FromRootToNode();
            var firstNode = categoryNodes.FirstOrDefault();
            var urlTail = firstNode.Route.Url;
            buildedCategories.Add(firstNode);
            foreach (var categoryNode in categoryNodes.Where(o => o.Parent != null))
            {
                if (!string.IsNullOrEmpty(categoryNode.Route.Url))
                {
                    urlTail += "/" + categoryNode.Route.Url;
                    var buildedCategory = categoryNode;
                    buildedCategory.Route.Url = urlTail;
                    buildedCategories.Add(buildedCategory);
                }
            }


            foreach (var categoryNode in buildedCategories)
            {
                categoryNode.Route.Url = categoryNode.Route.Url?.RemoveAdditionalSlashes();
                if (categoryNode.Route.Url?.FirstOrDefault() == '/')
                    categoryNode.Route.Url = categoryNode.Route.Url.Substring(1);
            }

            return buildedCategories;
        }
    }
}
