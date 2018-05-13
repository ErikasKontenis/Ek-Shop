using AutoMapper;
using Ek.Shop.Application.Services.AutoMappers.Profiles;

namespace Ek.Shop.Application.Services.AutoMappers
{
    public static class AutoMapperFactory
    {
        public static IMapper CreateMapper<T1>()
            where T1 : Profile, new()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new PagedListMapperProfile());
                config.AddProfile(new T1());
            }).CreateMapper();
        }

        // Override as much as is needed
        public static IMapper CreateMapper<T1, T2>()
            where T1 : Profile, new()
            where T2 : Profile, new()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new PagedListMapperProfile());
                config.AddProfile(new T1());
                config.AddProfile(new T2());
            }).CreateMapper();
        }

        public static IMapper CreateMapper<T1, T2, T3>()
            where T1 : Profile, new()
            where T2 : Profile, new()
            where T3 : Profile, new()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new PagedListMapperProfile());
                config.AddProfile(new T1());
                config.AddProfile(new T2());
                config.AddProfile(new T3());
            }).CreateMapper();
        }
    }
}
