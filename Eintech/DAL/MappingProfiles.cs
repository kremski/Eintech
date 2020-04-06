using AutoMapper;
using Eintech.DAL.Models;
using Eintech.Models;

namespace Eintech.DAL
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Person, PersonViewModel>()
                .IncludeAllDerived()
                .ReverseMap();

            CreateMap<Group, GroupViewModel>()
                .IncludeAllDerived()
                .ReverseMap();
        }
    }
}
