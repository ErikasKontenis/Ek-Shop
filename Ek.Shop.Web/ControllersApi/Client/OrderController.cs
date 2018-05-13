using Ek.Shop.Application.Orders;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ek.Shop.Web.ControllersApi.Client
{
    [ResponseCache(CacheProfileName = "ResponseCachingNever")]
    [Route("api/[controller]")]
    public class OrderController : ClientController
    {
        public OrderController(IBus bus)
            : base(bus)
        { }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderData()
        {
            var getOrderDataCommand = new GetOrderDataCommand();
            var orderDataDtoResult = await QueryProcessor.GetQueryHandler<GetOrderDataCommand, OrderDataDto>(getOrderDataCommand);
            if (orderDataDtoResult.Failure)
            {
                return BadRequest(orderDataDtoResult.ErrorMessages);
            }

            var orderDataDto = orderDataDtoResult.Object;
            return Ok(orderDataDto);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SubmitOrder([FromBody]SubmitOrderCommand submitOrderCommand)
        {
            var submitOrderDtoResult = await QueryProcessor.GetQueryHandler<SubmitOrderCommand, OrderDto>(submitOrderCommand);
            if (submitOrderDtoResult.Failure)
            {
                return BadRequest(submitOrderDtoResult.ErrorMessages);
            }

            var submitOrderDto = submitOrderDtoResult.Object;
            return Ok(submitOrderDto);
        }
    }
}
