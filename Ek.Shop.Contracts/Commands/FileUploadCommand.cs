using Microsoft.AspNetCore.Http;

namespace Ek.Shop.Contracts.Commands
{
    public class FileUploadCommand : ICommand
    {
        public FileUploadCommand()
        { }

        public FileUploadCommand(IFormFileCollection files)
        {
            Files = files;
        }

        public IFormFileCollection Files { get; set; }
    }
}
