using AutoMapper;
using Ek.Shop.Application.Routes;
using Ek.Shop.Domain.Categories;
using Ek.Shop.Domain.Products;
using Ek.Shop.Domain.Routes;
using System.Linq;

namespace Ek.Shop.Application.Services.AutoMappers.Profiles
{
    public class RouteMapperProfile : Profile
    {
        public RouteMapperProfile()
            : this("RouteMapperProfile")
        { }

        protected RouteMapperProfile(string profileName)
            : base(profileName)
        {
            CreateMap<Category, RouteDto>()
                .ForMember(x => x.AngularComponent, m => m.MapFrom(x => x.Route.AngularComponent.Code))
                .ForMember(x => x.Id, m => m.MapFrom(x => x.Route.Id))
                .ForMember(x => x.InputForm, m => m.MapFrom(x => x.Route.InputForm.Code))
                .ForMember(x => x.ItemId, m => m.MapFrom(x => x.Id))
                .ForMember(x => x.Url, m => m.MapFrom(x => x.Route.Url))
                .ForMember(x => x.Title, m => m.MapFrom(x => x.Route.Title));

            CreateMap<Product, RouteDto>()
                .ForMember(x => x.AngularComponent, m => m.MapFrom(x => x.Route.AngularComponent.Code))
                .ForMember(x => x.Id, m => m.MapFrom(x => x.Route.Id))
                .ForMember(x => x.InputForm, m => m.MapFrom(x => x.Route.InputForm.Code))
                .ForMember(x => x.ItemId, m => m.MapFrom(x => x.Id))
                .ForMember(x => x.Url, m => m.MapFrom(x => x.Route.Url))
                .ForMember(x => x.Title, m => m.MapFrom(x => x.Route.Title));

            CreateMap<Route, RouteDto>()
                .ForMember(x => x.AngularComponent, m => m.MapFrom(x => x.AngularComponent.Code))
                .ForMember(x => x.Id, m => m.MapFrom(x => x.Id))
                .ForMember(x => x.InputForm, m => m.MapFrom(x => x.InputForm.Code))
                .ForMember(x => x.ItemId, m => m.ResolveUsing(x => x.Category?.Id > 0 ? x.Category.Id : x.Product?.Id))
                .ForMember(x => x.Url, m => m.MapFrom(x => x.Url))
                .ForMember(x => x.Title, m => m.MapFrom(x => x.Title));
        }
    }
}
