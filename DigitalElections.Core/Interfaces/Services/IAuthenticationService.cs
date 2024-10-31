using DigitalElections.Core.DTOs.Response;
using DigitalElections.Core.DTOs;

namespace DigitalElections.Core.Interfaces.Services;

public interface IAuthenticationService
{
    Task<LoginResponseDTO> Login(LoginDTO dto);
    Task<LoginResponseDTO> LoginWithManagerAccount(LoginDTO dto);
}