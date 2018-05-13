using AutoMapper;
using Ek.Shop.Application.Classifiers;
using Ek.Shop.Domain.Phrases;

namespace Ek.Shop.Application.Services.AutoMappers.Profiles
{
    public class ClassifierMapperProfile : Profile
    {
        public ClassifierMapperProfile()
            : this("ClassifierMapperProfile")
        { }

        protected ClassifierMapperProfile(string profileName)
            : base(profileName)
        {
            CreateMap<Phrase, PhraseDto>()
                .ForMember(x => x.Value, m => m.MapFrom(x => x.Id))
                .ForMember(x => x.Text, m => m.MapFrom(x => x.Value));
        }
    }
}
