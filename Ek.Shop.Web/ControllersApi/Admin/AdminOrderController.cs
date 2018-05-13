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
    public class AdminOrderController : AdminController
    {
        public AdminOrderController(IBus bus)
            : base(bus)
        { }

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
    }
}
