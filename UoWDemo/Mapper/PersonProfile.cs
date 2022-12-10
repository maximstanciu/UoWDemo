using AutoMapper;
using UoWDemo.Entities;
using UoWDemo.Resources;

namespace UoWDemo.Mapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonResource>()
                .ForMember(t => t.Id, o => o.MapFrom(t => t.Id))
                .ForMember(t => t.FirstName, o => o.MapFrom(t => t.FirstName))
                .ForMember(t => t.LastName, o => o.MapFrom(t => t.LastName))
                .ForMember(t => t.CreatedAt, o => o.MapFrom(t => t.CreatedAt))
                .ForMember(t => t.UpdatedAt, o => o.MapFrom(t => t.UpdatedAt))
                .ForMember(t => t.Addresses, o => o.MapFrom(t => t.Addresses))
                .ReverseMap();
        }
    }
}
