using Ek.Shop.Application.Images;
using Ek.Shop.Contracts.Extensions;
using Ek.Shop.Domain.Characteristics;
using Ek.Shop.Domain.Images;
using System.Collections.Generic;

namespace Ek.Shop.Application.Services.Infrastructure.CommonHelpers
{
    public static class ImagesHelper
    {
        public static void MergeImages(this ICollection<Image> images, List<Characteristic> availableCharacteristics, List<ImageDto> imagesDto)
        {
            images.Clear();

            if (imagesDto.IsNullOrEmpty())
                return;

            foreach (var imageDto in imagesDto)
            {
                var image = new Image();
                image.Characteristics.MergeCharacteristics(availableCharacteristics, imageDto.Characteristics);
                image.ImageSizeTypeId = imageDto.ImageSizeTypeId.Value;
                image.Url = imageDto.Url;
                images.Add(image);
            }
        }
    }
}
