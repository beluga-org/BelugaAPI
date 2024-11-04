using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Interfaces;
using BelugaAPI.Persistence;
using BelugaAPI.Persistence.Context;

namespace BelugaAPI.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        User = new UserRepository(_context);
        Video = new VideoRepository(_context);
        AccessKey = new AccessKeyRepository(_context);
    }
    
    public IUserRepository User { get; private set; }
    public IVideoRepository Video { get; private set; }
    public IAccessKeyRepository AccessKey { get; private set; }
    
    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    
}