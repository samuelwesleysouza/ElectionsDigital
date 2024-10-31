using AutoMapper;
using DigitalElections.Core.DTOs;
using DigitalElections.Domain.Entities;
using DigitalElections.Core.Interfaces.Repositories;
using DigitalElections.Core.Interfaces.Repositories.Base;
using DigitalElections.Core.Interfaces.Services;
using Logar.Domain.Services.Base;

namespace DigitalElections.Domain.Services;

public class HelpFriendService : BaseService<HelpFriendDTO, HelpFriend>, IHelpFriendService
{
    private readonly IPersonRepository _personRepository;
    private readonly IUserRepository _userRepository;
    public HelpFriendService(IRepository<HelpFriend> repository, IMapper mapper, IPersonRepository personRepository, IUserRepository userRepository) : base(repository, mapper)
    {
        _personRepository = personRepository;
        _userRepository = userRepository;
    }

    public override async Task<List<HelpFriendDTO>> GetAll()
    {
        var helpFriends = await _repository.GetAll();

        return helpFriends.Select(helpFriend => new HelpFriendDTO
        {
            Id = helpFriend.Id,
            PersonId = helpFriend.PersonId,
            UserId = helpFriend.UserId,
            WhyHelp = helpFriend.WhyHelp,
            PersonName = helpFriend.Person.Name,
            LeaderName = helpFriend.Users.Name
        }).ToList();
    }

    public override async Task<HelpFriendDTO> Create(HelpFriendDTO dto)
    {
        var person = await _personRepository.GetById(dto.PersonId);

        if (person is null)
        {
            throw new HttpRequestException("Person is not found");
        }

        var user = await _userRepository.GetById(dto.UserId);

        if (user is null)
        {
            throw new HttpRequestException("User is not found");
        }

        var newUser = _mapper.Map<HelpFriend>(dto);

        newUser = await _repository.Create(newUser);

        return _mapper.Map<HelpFriendDTO>(newUser);
    }
}