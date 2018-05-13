using Ek.Shop.Base.Data.Caches;
using Ek.Shop.Base.Data.DbContexts;
using Ek.Shop.Base.Data.Queries.Queries;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Core.Models;
using Ek.Shop.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Data.Categories
{
    public class GetCategoryBaseQuery : Query<GetCategoryCommand, Category>
    {
        private readonly ICache _cache;

        public GetCategoryBaseQuery(EkShopContext dbContext,
            ICache cache)
            : base (dbContext)
        {
            _cache = cache;
        }

        private void GetCategoryParents(int? categoryId, List<int> resultsList)
        {
            if (!categoryId.HasValue)
                return;

            var category = _cache.GetOrAdd($"GetCategoryBaseQuery_GetCategoryParents_{categoryId}", CacheRegions.Category, () =>
            {
                return DbContext.Categories.Select(o => new Category { Id = o.Id, ParentId = o.ParentId }).FirstOrDefault(o => o.Id == categoryId);
            }, new CacheOptions() { Timeout = TimeSpan.FromDays(1) });

            if (categoryId.HasValue)
            {
                GetCategoryParents(category.ParentId, resultsList);
                resultsList.Add(category.Id);
            }
        }

        public override IQueryable<Category> Execute(GetCategoryCommand command)
        {
            var categoryParents = new List<int>();
            GetCategoryParents(command.CategoryId, categoryParents);

            var categoriesQuery = DbContext.Categories
                .Include(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Characteristics)
                .Include(o => o.Parent)
                .Include(o => o.Children).ThenInclude(o => o.Images).ThenInclude(o => o.ImageSizeType)
                .Include(o => o.Children).ThenInclude(o => o.Images).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Children).ThenInclude(o => o.Images).ThenInclude(o => o.Characteristics)
                .Include(o => o.Children).ThenInclude(o => o.Route).ThenInclude(o => o.AngularComponent)
                .Include(o => o.Children).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Children).ThenInclude(o => o.Characteristics)
                .Include(o => o.CategoryType)
                .Include(o => o.Images).ThenInclude(o => o.ImageSizeType)
                .Include(o => o.Images).ThenInclude(o => o.Characteristics).ThenInclude(o => o.Characteristic)
                .Include(o => o.Images).ThenInclude(o => o.Characteristics)
                .Include(o => o.Route).ThenInclude(o => o.AngularComponent)
                .Include(o => o.Route).ThenInclude(o => o.InputForm)
                .Where(o => categoryParents.Contains(o.Id));

            return categoriesQuery;
        }
    }
}
