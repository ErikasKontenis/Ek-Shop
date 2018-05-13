using Ek.Shop.Application.Services.InputForms;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Data.InputForms;
using Ek.Shop.Data.SystemSettings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Ek.Shop.Tests.QueryHandlers
{
    [TestClass]
    public class InputFormTests : TestUtil
    {
        private GetSystemSettingQuery _getSystemSettingQuery;
        private GetInputFormQuery _getInputFormQuery;
        private GetInputFormQueryHandler _getInputFormQueryHandler;

        public InputFormTests()
        {
            _getSystemSettingQuery = new GetSystemSettingQuery(DbContext);
            _getInputFormQuery = new GetInputFormQuery(DbContext, _getSystemSettingQuery);
            _getInputFormQueryHandler = new GetInputFormQueryHandler(_getInputFormQuery);
        }

        [TestMethod]
        public async Task ShouldGetInputForm()
        {
            // Arrange
            var getInputFormCommand = new GetInputFormCommand();

            // Act
            var result = await _getInputFormQueryHandler.Handle(getInputFormCommand);

            // Assert
            Assert.IsNotNull(result?.Object);
        }
    }
}
