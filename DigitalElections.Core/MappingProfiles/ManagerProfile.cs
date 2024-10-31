using AutoMapper;
using DigitalElections.Core.DTOs;
using DigitalElections.Core.DTOs.Response;
using DigitalElections.Domain.Entities;

namespace DigitalElections.Core.MappingProfiles;

public class ManagerProfile : Profile
{
    public ManagerProfile()
    {
        CreateMap<Manager, ManagerDTO>().ReverseMap();
        CreateMap<Manager, LoginData>();
    }
}