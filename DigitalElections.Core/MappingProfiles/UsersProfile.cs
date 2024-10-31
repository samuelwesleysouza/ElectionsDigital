using AutoMapper;
using DigitalElections.Core.DTOs;
using DigitalElections.Core.DTOs.Response;
using DigitalElections.Domain.Entities;

namespace DigitalElections.Core.MappingProfiles;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<UserDTO, Users>().ReverseMap();
        CreateMap<Users, LoginData>();
    }
}