using AutoMapper;
using Ek.Shop.Application.Baskets;
using Ek.Shop.Domain.Baskets;

namespace Ek.Shop.Application.Services.AutoMappers.Profiles
{
    public class BasketMapperProfile : Profile
    {
        public BasketMapperProfile()
            : this("BasketMapperProfile")
        { }

        protected BasketMapperProfile(string profileName)
            : base(profileName)
        {
            CreateMap<Basket, BasketDto>();

            CreateMap<BasketItem, BasketItemDto>()
                .ReverseMap()
                .ForMember(x => x.Product, o => o.Ignore());
        }
    }
}
