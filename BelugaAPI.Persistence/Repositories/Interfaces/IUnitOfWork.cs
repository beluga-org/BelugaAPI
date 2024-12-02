namespace BelugaAPI.Persistence.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> Complete();
    IUserRepository User { get; }
    IVideoRepository Video { get; }
    ITranslationRepository Translation { get; }
    IAccessKeyRepository AccessKey { get; }
    IChatRepository Chat { get; }
}