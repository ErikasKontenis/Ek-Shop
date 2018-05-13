using AutoMapper;
using Ek.Shop.Core.Models;

namespace Ek.Shop.Application.Services.AutoMappers.Profiles
{
    public class PagedListMapperProfile : Profile
    {
        public PagedListMapperProfile()
            : this("PagedListMapperProfile")
        { }

        protected PagedListMapperProfile(string profileName)
            : base(profileName)
        {
            CreateMap(typeof(PagedList<>), typeof(PagedList<>));
        }
    }
}
