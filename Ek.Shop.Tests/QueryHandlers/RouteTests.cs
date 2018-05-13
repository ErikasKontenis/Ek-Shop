using Ek.Shop.Application.Services.Routes;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Data.Categories;
using Ek.Shop.Data.Routes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Ek.Shop.Tests.QueryHandlers
{
    [TestClass]
    public class RouteTests : TestUtil
    {
        private GetCategoryBaseQuery _getCategoryBaseQuery;
        private GetCategoryQuery _getCategoryQuery;
        private GetRouteQuery _getRouteQuery;
        private ListRoutesQuery _listRoutesQuery;
        private GetRouteQueryHandler _listRouteQueryHandler;
        private ListRoutesQueryHandler _listRoutesQueryHandler;
        private GetRouteByUrlQueryHandler _getRouteByUrlQueryHandler;

        public RouteTests()
        {
            _getCategoryBaseQuery = new GetCategoryBaseQuery(DbContext, Cache);
            _getCategoryQuery = new GetCategoryQuery(DbContext, _getCategoryBaseQuery, WorkContext);
            _getRouteQuery = new GetRouteQuery(DbContext);
            _listRoutesQuery = new ListRoutesQuery(DbContext);
            _listRouteQueryHandler = new GetRouteQueryHandler(_getRouteQuery);
            _listRoutesQueryHandler = new ListRoutesQueryHandler(_listRoutesQuery);
            _getRouteByUrlQueryHandler = new GetRouteByUrlQueryHandler(_listRoutesQuery, _getCategoryQuery);
        }

        [TestMethod]
        public async Task ShouldGetRoute()
        {
            // Arrange
            var getRouteCommand = new GetRouteCommand(5);

            // Act
            var result = await _listRouteQueryHandler.Handle(getRouteCommand);

            // Assert
            Assert.IsNotNull(result?.Object);
        }

        [TestMethod]
        public async Task ShouldGetRouteByUrl()
        {
            // Arrange
            var getRouteCommand = new GetRouteByUrlCommand("/kanceliarines-prekes/popieriaus-produktai", WorkContext.WorkingLanguageId);

            // Act
            var result = await _getRouteByUrlQueryHandler.Handle(getRouteCommand);

            // Assert
            Assert.IsNotNull(result?.Object);
        }

        [TestMethod]
        public async Task ShouldGetRoutesQuery()
        {
            // Arrange
            var listRoutesCommand = new ListRoutesCommand();

            // Act
            var result = await _listRoutesQuery.Query(listRoutesCommand);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ShouldGetRoutesQueryHandler()
        {
            // Arrange
            var listRoutesCommand = new ListRoutesCommand();

            // Act
            var result = await _listRoutesQueryHandler.Handle(listRoutesCommand);

            // Assert
            Assert.IsNotNull(result?.Object);
        }
    }
}
