using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Ek.Shop.Core.Extensions
{
    public static class FormFileExtensions
    {
        public static string GetFilename(this IFormFile file)
        {
            return file.FileName;
        }

        public static async Task<MemoryStream> GetFileStream(this IFormFile file)
        {
            MemoryStream filestream = new MemoryStream();
            await file.CopyToAsync(filestream);
            return filestream;
        }

        public static async Task<byte[]> GetFileArray(this IFormFile file)
        {
            MemoryStream filestream = new MemoryStream();
            await file.CopyToAsync(filestream);
            return filestream.ToArray();
        }
    }
}
