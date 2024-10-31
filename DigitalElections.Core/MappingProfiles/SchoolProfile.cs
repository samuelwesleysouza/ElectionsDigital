using AutoMapper;
using DigitalElections.Core.DTOs;
using DigitalElections.Domain.Entities;

namespace DigitalElections.Core.MappingProfiles;

public class SchoolProfile : Profile
{
    public SchoolProfile()
    {
        CreateMap<School, SchoolDTO>().ReverseMap();
    }
}