using Ek.Shop.Base.Data.Extensions;
using Ek.Shop.Core.Enums;
using Ek.Shop.Domain.Images;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ek.Shop.Base.Data.DatabaseSeeds.Classifiers
{
    public static class ImageSizeTypeSeedExtensions
    {
        public static void Seed<TDbContet>(TDbContet dbContext)
            where TDbContet : DbContext
        {
            DatabaseSeedExtensions.AddSeeds(dbContext, new List<ImageSizeType>()
            {
                new ImageSizeType
                {
                    Code = ImageSizeTypes.Small
                },
                new ImageSizeType
                {
                    Code = ImageSizeTypes.Big
                }
            });
        }
    }
}
