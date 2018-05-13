using Ek.Shop.Application.Images;
using System.Collections.Generic;

namespace Ek.Shop.Application.Classifiers
{
    public class CategoryItemDto
    {
        public Dictionary<string, string> Characteristics { get; set; }

        public int DetailsCount { get; set; }

        public decimal Discount { get; set; }

        public int Id { get; set; }

        public List<ImageDto> Images { get; set; }

        public decimal Price { get; set; }

        public string Url { get; set; }
    }
}
