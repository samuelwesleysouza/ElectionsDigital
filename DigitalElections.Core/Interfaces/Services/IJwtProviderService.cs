using DigitalElections.Domain.Enums;

namespace DigitalElections.Core.Interfaces.Services;

public interface IJwtProviderService
{
    string GenerateToken(UserTypeEnum role, long userId);
}