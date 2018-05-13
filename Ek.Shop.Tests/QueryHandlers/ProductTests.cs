using Ek.Shop.Application.Services.Products;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Data.Categories;
using Ek.Shop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Ek.Shop.Tests.QueryHandlers
{
    [TestClass]
    public class ProductTests : TestUtil
    {
        private GetCategoryBaseQuery _getCategoryBaseQuery;
        private GetProductQuery _getProductQuery;
        private ListProductsQuery _listProductsQuery;
        private GetProductQueryHandler _getProductQueryHandler;
        private ListProductsQueryHandler _listProductsQueryHandler;

        public ProductTests()
        {
            _getCategoryBaseQuery = new GetCategoryBaseQuery(DbContext, Cache);
            _getProductQuery = new GetProductQuery(DbContext, _getCategoryBaseQuery);
            _listProductsQuery = new ListProductsQuery(DbContext);
            _getProductQueryHandler = new GetProductQueryHandler(_getProductQuery);
            _listProductsQueryHandler = new ListProductsQueryHandler(_listProductsQuery);
        }

        [TestMethod]
        public async Task ShouldGetProduct()
        {
            // Arrange
            var getProductCommand = new GetProductCommand(2, WorkContext.WorkingLanguageId);

            // Act
            var result = await _getProductQueryHandler.Handle(getProductCommand);

            // Assert
            Assert.IsNotNull(result?.Object);
        }

        [TestMethod]
        public async Task ShouldListProductsQuery()
        {
            // Arrange
            var listProductsCommand = new ListProductsCommand(1, 36);

            // Act
            var result = await _listProductsQuery.Query(listProductsCommand);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ShouldListProducts()
        {
            // Arrange
            var listProductsCommand = new ListProductsCommand(1, 36);

            // Act
            var result = await _listProductsQueryHandler.Handle(listProductsCommand);

            // Assert
            Assert.IsNotNull(result?.Object);
        }
    }
}
