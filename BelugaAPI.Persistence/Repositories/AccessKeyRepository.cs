using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Context;
using BelugaAPI.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BelugaAPI.Persistence.Repositories;

public class AccessKeyRepository : Repository<AccessKey>, IAccessKeyRepository
{
    public AccessKeyRepository(ApplicationDbContext context) : base(context)
    {
    }

    public List<AccessKey> FetchAllByUserId(string userId)
    {
        var queryFilter = _entities
            .AsNoTracking()
            .Where(x =>
                x.userId == userId &&
                x.deleted == null);
            
        return queryFilter.ToList();
    }

    public AccessKey? FetchById(string id)
    {
        var queryFilter = _entities
            .FirstOrDefault(x => x.id == id);

        return queryFilter;
    }
}

