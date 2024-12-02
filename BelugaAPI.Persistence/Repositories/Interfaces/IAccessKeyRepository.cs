using BelugaAPI.Core.Entities;

namespace BelugaAPI.Persistence.Repositories.Interfaces;

public interface IAccessKeyRepository : IRepository<AccessKey>
{
    AccessKey? FetchById(string id);
    List<AccessKey> FetchAllByUserId(string userId);
}