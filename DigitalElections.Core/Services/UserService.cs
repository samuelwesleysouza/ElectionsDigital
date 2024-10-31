﻿using AutoMapper;
using DigitalElections.Core.DTOs;
using DigitalElections.Core.Interfaces.Repositories;
using DigitalElections.Core.Interfaces.Repositories.Base;
using DigitalElections.Core.Interfaces.Services;
using DigitalElections.Core.Utils;
using DigitalElections.Domain.Entities;
using DigitalElections.Domain.Enums;
using Logar.Domain.Services.Base;
using System.Net;

namespace DigitalElections.Domain.Services;

public class UserService : BaseService<UserDTO, Users>, IUserService
{
    private readonly IUserRepository _repository;
    private readonly IManagerRepository _managerRepository;

    public UserService(IRepository<Users> repository, IMapper mapper, IUserRepository userRepository, IManagerRepository managerRepository) : base(repository, mapper)
    {
        _repository = userRepository;
        _managerRepository = managerRepository;
    }

    public override async Task<UserDTO> Create(UserDTO dto)
    {
        if (String.IsNullOrEmpty(dto.Email)) throw new ArgumentNullException(paramName: "email");
        if (String.IsNullOrEmpty(dto.Password)) throw new ArgumentNullException(paramName: "password");
        if (dto.Id is not 0) dto.Id = 0;

        var userManager = await _managerRepository.GetManagerById(dto.ManagerId) ?? throw new HttpRequestException("Manager is not found", null, HttpStatusCode.BadRequest);

        if (dto.UserType == UserTypeEnum.Admin)
        {
            dto.ManagerId = null;
        }

        var newUser = _mapper.Map<Users>(dto);

        newUser.Password = Hashing.UseArgon2(dto.Password);
        newUser.ManagerId = userManager.Id;

        newUser = await _repository.Create(newUser);

        return _mapper.Map<UserDTO>(newUser);
    }

    public async Task<List<LeaderRegistersDTO>> CountVotersByLeaders()
    {
        return await _repository.GetLeaderAndYourPersonsRegister();
    }
}