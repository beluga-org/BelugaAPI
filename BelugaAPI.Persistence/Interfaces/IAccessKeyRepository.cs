using BelugaAPI.Core.Entities;

namespace BelugaAPI.Persistence.Interfaces;

public interface IAccessKeyRepository : IRepository<AccessKey>
{
    AccessKey? FetchById(int id);
    List<AccessKey> FetchAllByUserId(int userId);
}