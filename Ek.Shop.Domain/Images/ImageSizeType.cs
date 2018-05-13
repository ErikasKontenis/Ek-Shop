using System.Collections.Generic;

namespace Ek.Shop.Domain.Images
{
    public class ImageSizeType : Classifier
    {
        public ImageSizeType()
        {
            Images = new HashSet<Image>();
        }

        public ICollection<Image> Images { get; set; }
    }
}
