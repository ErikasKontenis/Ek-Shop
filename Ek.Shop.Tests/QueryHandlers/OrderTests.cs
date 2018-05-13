using Ek.Shop.Application.Services.Classifiers;
using Ek.Shop.Application.Services.Orders;
using Ek.Shop.Base.Application.Services.QueryHandlers.ClassifierQueryHandler;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Data.Classifiers;
using Ek.Shop.Data.Orders;
using Ek.Shop.Domain.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Ek.Shop.Tests.QueryHandlers
{
    [TestClass]
    public class OrderTests : TestUtil
    {
        private ListOrdersQuery _listOrdersQuery;
        private ListOrderStatusesQuery _listOrderStatusesQuery;
        private ListShippingMethodsQuery _listShippingMethodsQuery;
        private ListPhrasesByNameQuery _listPhrasesByNameQuery;
        private ListOrderStatusesQueryHandler _listOrderStatusesQueryHandler;
        private ListShippingMethodsQueryHandler _listShippingMethodsQueryHandler;
        private ListOrdersQueryHandler _listOrdersQueryHandler;

        public OrderTests()
        {
            _listOrdersQuery = new ListOrdersQuery(DbContext);
            _listOrderStatusesQuery = new ListOrderStatusesQuery(DbContext);
            _listShippingMethodsQuery = new ListShippingMethodsQuery(DbContext);
            _listPhrasesByNameQuery = new ListPhrasesByNameQuery(DbContext, WorkContext);
            var classifierBus = new ClassifierBus<ListOrderStatusesCommand, OrderStatus>(_listOrderStatusesQuery, _listPhrasesByNameQuery);
            _listOrderStatusesQueryHandler = new ListOrderStatusesQueryHandler(classifierBus);
            _listShippingMethodsQueryHandler = new ListShippingMethodsQueryHandler(_listShippingMethodsQuery, _listPhrasesByNameQuery);
            _listOrdersQueryHandler = new ListOrdersQueryHandler(_listOrderStatusesQueryHandler, _listShippingMethodsQueryHandler, _listOrdersQuery);
        }

        [TestMethod]
        public async Task ShouldListOrders()
        {
            // Arrange
            var listOrdersCommand = new ListOrdersCommand(1);

            // Act
            var result = await _listOrdersQueryHandler.Handle(listOrdersCommand);

            // Assert
            Assert.IsNotNull(result?.Object);
        }
    }
}
