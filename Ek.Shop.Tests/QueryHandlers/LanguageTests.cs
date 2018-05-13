using Ek.Shop.Application.Services.Languages;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Data.Languages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Ek.Shop.Tests.QueryHandlers
{
    [TestClass]
    public class LanguageTests : TestUtil
    {
        private GetLanguageQuery _getLanguageQuery;
        private GetLanguageQueryHandler _getLanguageQueryHandler;

        public LanguageTests()
        {
            _getLanguageQuery = new GetLanguageQuery(DbContext, WorkContext);
            _getLanguageQueryHandler = new GetLanguageQueryHandler(_getLanguageQuery);
        }

        [TestMethod]
        public async Task ShouldGetLanguage()
        {
            // Arrange
            var getLanguageCommand = new GetLanguageCommand(2);

            // Act
            var result = await _getLanguageQueryHandler.Handle(getLanguageCommand);

            // Assert
            Assert.IsNotNull(result?.Object);
        }
    }
}
