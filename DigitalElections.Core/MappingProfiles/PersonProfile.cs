using AutoMapper;
using DigitalElections.Core.DTOs;
using DigitalElections.Domain.Entities;

namespace DigitalElections.Core.MappingProfiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonDTO>().ReverseMap();
    }
}