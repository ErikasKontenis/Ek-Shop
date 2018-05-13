using Ek.Shop.Base.Application.Services.QueryHandlers.QueryHandler;
using Ek.Shop.Contracts;
using Ek.Shop.Contracts.Commands;
using Ek.Shop.Core.Extensions;
using Ek.Shop.Core.Models;
using System.IO;
using System.Threading.Tasks;

namespace Ek.Shop.Application.Services.FileUploads
{
    public class FileUploadQueryHandler : QueryHandler<FileUploadCommand, NoneResult>
    {


        public FileUploadQueryHandler()
        {

        }

        public override async Task<ActionResult<NoneResult>> Handle(FileUploadCommand command)
        {
            var files = command.Files;
            if (files == null || files.Count == 0)
                return Error();

            foreach (var file in files)
            {
                var path = Path.Combine(
                        Directory.GetCurrentDirectory(), @"wwwroot\content\uploads",
                        file.GetFilename());

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Ok(null);
        }
    }
}
