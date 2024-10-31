using DigitalElections.Domain.Entities.Base;
using Shared.Infrastructure.Interfaces;

namespace DigitalElections.Core.Interfaces.Repositories.Base;

public interface ISensitiveRepository<M> : IRepository<M>
    where M : BaseEntity, IUserSensitive
{ }