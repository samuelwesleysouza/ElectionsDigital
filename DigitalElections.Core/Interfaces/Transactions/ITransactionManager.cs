namespace Logar.Core.Interfaces.Transactions;

public interface ITransactionManager : IDisposable
{
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}