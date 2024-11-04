using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Context;
using BelugaAPI.Persistence.Interfaces;

namespace BelugaAPI.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
        
    }
}