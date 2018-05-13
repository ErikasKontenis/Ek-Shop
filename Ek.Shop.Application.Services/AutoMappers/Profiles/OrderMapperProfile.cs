using AutoMapper;
using Ek.Shop.Application.Orders;
using Ek.Shop.Domain.Orders;

namespace Ek.Shop.Application.Services.AutoMappers.Profiles
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
            : this("OrderMapperProfile")
        { }

        protected OrderMapperProfile(string profileName)
            : base(profileName)
        {
            CreateMap<Order, OrderDto>()
                .ForMember(x => x.OrderStatus, m => m.MapFrom(x => x.OrderStatus.Code))
                .ForMember(x => x.PaymentMethod, m => m.MapFrom(x => x.PaymentMethod.Code))
                .ForMember(x => x.PaymentMethodType, m => m.MapFrom(x => x.PaymentMethodType.Code))
                .ForMember(x => x.ShippingMethod, m => m.MapFrom(x => x.ShippingMethod.Code))
                .ReverseMap()
                .ForMember(x => x.Basket, o => o.Ignore())
                .ForMember(x => x.BasketId, o => o.Ignore())
                .ForMember(x => x.Characteristics, o => o.Ignore())
                .ForMember(x => x.OrderStatus, o => o.Ignore())
                .ForMember(x => x.PaymentMethod, o => o.Ignore())
                .ForMember(x => x.PaymentMethodId, o => o.Ignore())
                .ForMember(x => x.PaymentMethodType, o => o.Ignore())
                .ForMember(x => x.PaymentMethodTypeId, o => o.Ignore())
                .ForMember(x => x.ShippingMethod, o => o.Ignore())
                .ForMember(x => x.ShippingMethodId, o => o.Ignore());
        }
    }
}
