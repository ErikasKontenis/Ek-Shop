using System.Collections.Generic;

namespace Ek.Shop.Application.Images
{
    public class ImageDto
    {
        public Dictionary<string, string> Characteristics { get; set; }

        public string ImageSizeType { get; set; }

        public int? ImageSizeTypeId { get; set; }

        public string Url { get; set; }
    }
}
