using AutoMapper;
using Ek.Shop.Application.Images;
using Ek.Shop.Application.Services.Infrastructure.CommonHelpers;
using Ek.Shop.Domain.Images;

namespace Ek.Shop.Application.Services.AutoMappers.Profiles
{
    public class ImageMapperProfile : Profile
    {
        public ImageMapperProfile()
            : this("ImageMapperProfile")
        { }

        protected ImageMapperProfile(string profileName)
            : base(profileName)
        {
            // TODO: fix working langaugeId
            CreateMap<Image, ImageDto>()
                .ForMember(x => x.Characteristics, m => m.MapFrom(x => CharacteristicsHelper.BuildCharacteristics<ImageCharacteristic, ImageCharacteristicTranslation>(x, x.Characteristics, 1)))
                .ForMember(x => x.ImageSizeType, m => m.MapFrom(x => x.ImageSizeType.Code))
                .ForMember(x => x.ImageSizeTypeId, m => m.MapFrom(x => x.ImageSizeType.Id));

            CreateMap<ImageDto, Image>()
                .ForMember(x => x.Characteristics, o => o.Ignore());

            CreateMissingTypeMaps = true;
        }
    }
}
