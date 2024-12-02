using BelugaAPI.Core.Entities;

namespace BelugaAPI.Persistence.Repositories.Interfaces;

public interface IChatRepository : IRepository<Chat>
{
    Chat? FetchById(string userId, string videoId);
}