namespace BelugaAPI.Persistence.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> Complete();
    IUserRepository User { get; }
    IVideoRepository Video { get; }
    IAccessKeyRepository AccessKey { get; }
}