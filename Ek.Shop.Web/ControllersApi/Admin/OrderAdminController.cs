using Ek.Shop.Application.Orders;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Models;
using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ek.Shop.Web.ControllersApi.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class OrderAdminController : AdminController
    {
        public OrderAdminController(IBus bus)
            : base(bus)
        { }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditOrderData(int id)
        {
            var getEditOrderDataCommand = new GetEditOrderDataCommand(id);
            var editOrderDataDtoResult = await QueryProcessor.GetQueryHandler<GetEditOrderDataCommand, EditOrderDataDto>(getEditOrderDataCommand);
            if (editOrderDataDtoResult.Failure)
            {
                return BadRequest(editOrderDataDtoResult.ErrorMessages);
            }

            var editOrderDataDto = editOrderDataDtoResult.Object;
            return Ok(editOrderDataDto);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListOrders(ListOrdersCommand listOrdersCommand)
        {
            var pagedOrdersDtoResult = await QueryProcessor.GetQueryHandler<ListOrdersCommand, PagedList<OrderDto>>(listOrdersCommand);
            if (pagedOrdersDtoResult.Failure)
            {
                return BadRequest(pagedOrdersDtoResult.ErrorMessages);
            }

            var pagedOrdersDto = pagedOrdersDtoResult.Object;
            return Ok(pagedOrdersDto);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SaveOrder([FromBody]SaveOrderCommand saveOrderCommand)
        {
            var orderDtoResult = await QueryProcessor.GetQueryHandler<SaveOrderCommand, OrderDto>(saveOrderCommand);
            if (orderDtoResult.Failure)
            {
                return BadRequest(orderDtoResult.ErrorMessages);
            }

            var orderDto = orderDtoResult.Object;
            return Ok(true);
        }
    }
}
