﻿using AutoMapper;
using DigitalElections.Core.DTOs;
using DigitalElections.Core.Interfaces.Repositories;
using DigitalElections.Core.Interfaces.Repositories.Base;
using DigitalElections.Core.Interfaces.Services;
using DigitalElections.Core.Utils;
using DigitalElections.Domain.Entities;
using Logar.Domain.Services.Base;

namespace DigitalElections.Core.Services;

public class ManagerService : BaseService<ManagerDTO, Manager>, IManagerService
{
    private readonly IManagerRepository _managerRepository;
    public ManagerService(IRepository<Manager> repository, IMapper mapper, IManagerRepository managerRepository) : base(repository, mapper)
    {
        _managerRepository = managerRepository;
    }

    public override async Task<ManagerDTO> Create(ManagerDTO dto)
    {
        if (String.IsNullOrEmpty(dto.Email)) throw new ArgumentNullException(paramName: "email");
        if (String.IsNullOrEmpty(dto.Password)) throw new ArgumentNullException(paramName: "password");
        if (dto.Id is not 0) dto.Id = 0;

        var newUser = _mapper.Map<Manager>(dto);

        newUser.Password = Hashing.UseArgon2(dto.Password);

        newUser = await _repository.Create(newUser);

        return _mapper.Map<ManagerDTO>(newUser);
    }

    public async Task<List<Users>> GetLeaders()
    {
        return await _managerRepository.GetLeaders();
    }
}