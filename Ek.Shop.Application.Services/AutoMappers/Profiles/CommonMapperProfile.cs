using AutoMapper;

namespace Ek.Shop.Application.Services.AutoMappers.Profiles
{
    public class CommonMapperProfile<TSource, TDestination> : Profile
        where TSource : class
        where TDestination : class
    {
        public CommonMapperProfile()
            : this("CommonProfile")
        { }

        protected CommonMapperProfile(string profileName)
            : base(profileName)
        {
            CreateMap<TSource, TDestination>();
            CreateMissingTypeMaps = true;
        }
    }
}
