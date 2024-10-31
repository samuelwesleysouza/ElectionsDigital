using AutoMapper;
using DigitalElections.Core.DTOs;
using DigitalElections.Domain.Entities;

namespace DigitalElections.Core.MappingProfiles;

public class HelpFriendProfile : Profile
{
    public HelpFriendProfile()
    {
        CreateMap<HelpFriend, HelpFriendDTO>().ReverseMap();
    }
}