using Ek.Shop.Contracts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ek.Shop.Web.ControllersApi.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class FileUploadAdminController : AdminController
    {
        public FileUploadAdminController(IBus bus)
            : base(bus)
        { }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadFiles()
        {
            var files = Request?.Form?.Files;
            var fileUploadResult = await QueryProcessor.GetQueryHandler<FileUploadCommand, NoneResult>(new FileUploadCommand(files));
            if (fileUploadResult.Failure)
            {
                return BadRequest(fileUploadResult.ErrorMessages);
            }

            return Ok(fileUploadResult.Success);
        }
    }
}
