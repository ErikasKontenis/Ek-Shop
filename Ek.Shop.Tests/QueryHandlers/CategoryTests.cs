using Ek.Shop.Application.Services.Categories;
using Ek.Shop.Application.Services.InputForms;
using Ek.Shop.Application.Services.Products;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Enums;
using Ek.Shop.Data.Categories;
using Ek.Shop.Data.InputForms;
using Ek.Shop.Data.Products;
using Ek.Shop.Data.SystemSettings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Ek.Shop.Tests.QueryHandlers
{
    [TestClass]
    public class CategoryTests : TestUtil
    {
        private GetSystemSettingQuery _getSystemSettingQuery;
        private GetInputFormQuery _getInputFormQuery;
        private GetCategoryBaseQuery _getCategoryBaseQuery;
        private GetCategoryQuery _getCategoryQuery;
        private ListCategoriesQuery _listCategoriesQuery;
        private ListProductsByCategoryQuery _listProductsByCategoryQuery;
        private ListCategoryNavigationsQueryHandler _listCategoryNavigationsQueryHandler;
        private GetCategoryQueryHandler _getCategoryQueryHandler;
        private ListCategoriesQueryHandler _listCategoriesQueryHandler;
        private ListProductsByCategoryQueryHandler _listProductsByCategoryQueryHandler;
        private GetInputFormQueryHandler _getInputFormQueryHandler;

        public CategoryTests()
        {
            _getSystemSettingQuery = new GetSystemSettingQuery(DbContext);
            _getInputFormQuery = new GetInputFormQuery(DbContext, _getSystemSettingQuery);
            _getCategoryBaseQuery = new GetCategoryBaseQuery(DbContext, Cache);
            _getCategoryQuery = new GetCategoryQuery(DbContext, _getCategoryBaseQuery, WorkContext);
            _listCategoriesQuery = new ListCategoriesQuery(DbContext);
            _listProductsByCategoryQuery = new ListProductsByCategoryQuery(DbContext);
            _listCategoryNavigationsQueryHandler = new ListCategoryNavigationsQueryHandler(_listCategoriesQuery);
            _getInputFormQueryHandler = new GetInputFormQueryHandler(_getInputFormQuery);
            _getCategoryQueryHandler = new GetCategoryQueryHandler(_getCategoryQuery, WorkContext);
            _listCategoriesQueryHandler = new ListCategoriesQueryHandler(_listCategoriesQuery);
            _listProductsByCategoryQueryHandler = new ListProductsByCategoryQueryHandler(_listProductsByCategoryQuery);
        }

        [TestMethod]
        public async Task ShouldGetCategoryQuery()
        {
            // Arrange
            var getCategoryCommand = new GetCategoryCommand(7, WorkContext.WorkingLanguageId);

            // Act
            var category = await _getCategoryQuery.Query(getCategoryCommand);

            // Assert
            Assert.IsNotNull(category);
        }

        [TestMethod]
        public async Task ShouldGetCategory()
        {
            // Arrange
            var listCategoriesCommand = new ListCategoriesCommand(1, WorkContext.WorkingLanguageId, true);
            var categoryId = (await _listCategoriesQuery.Query(listCategoriesCommand)).Items
                .FirstOrDefault(o => o.Route.AngularComponent.Code == AngularComponents.ProductCategoryComponent).Id;
            var getCategoryCommand = new GetCategoryCommand(7, WorkContext.WorkingLanguageId);
            var listProductsByCategoryCommand = new ListProductsByCategoryCommand(7, WorkContext.WorkingLanguageId, pageIndex: 1, pageSize: 24);

            // Act
            var categoryDto = (await _getCategoryQueryHandler.Handle(getCategoryCommand)).Object;
            var productsDto = (await _listProductsByCategoryQueryHandler.Handle(listProductsByCategoryCommand));

            // Assert
            Assert.IsNotNull(categoryDto);
            Assert.IsNotNull(productsDto);
        }

        [TestMethod]
        public async Task ShouldListCategories()
        {
            // Arrange
            var listCategoriesCommand = new ListCategoriesCommand(2, WorkContext.WorkingLanguageId, true, pageIndex:1, pageSize:1);

            // Act
            var result = await _listCategoriesQueryHandler.Handle(listCategoriesCommand);

            // Assert
            Assert.IsNotNull(result?.Object);
        }

        [TestMethod]
        public async Task ShouldGetSubCategory()
        {
            // Arrange
            var listCategoriesCommand = new ListCategoriesCommand(1, WorkContext.WorkingLanguageId, true);
            var categoryId = (await _listCategoriesQuery.Query(listCategoriesCommand)).Items
                .FirstOrDefault(o => o.Route.AngularComponent.Code == AngularComponents.SubCategoryComponent).Id;
            var getCategoryCommand = new GetCategoryCommand(categoryId, WorkContext.WorkingLanguageId);

            // Act
            var result = await _getCategoryQueryHandler.Handle(getCategoryCommand);

            // Assert
            Assert.IsNotNull(result?.Object);
        }

        [TestMethod]
        public async Task ShouldGetCategoryNavigations()
        {
            // Arrange
            var listCategoriesCommand = new ListCategoriesCommand(1, WorkContext.WorkingLanguageId, true);

            // Act
            var result = await _listCategoryNavigationsQueryHandler.Handle(listCategoriesCommand);

            // Assert
            Assert.IsNotNull(result?.Object);
        }
    }
}
