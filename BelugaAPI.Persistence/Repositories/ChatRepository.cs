using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Context;
using BelugaAPI.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BelugaAPI.Persistence.Repositories;

public class ChatRepository : Repository<Chat>, IChatRepository
{
    public ChatRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Chat? FetchById(string userId, string videoId)
    {
        var queryFilter = _entities
            .AsNoTracking();

        return queryFilter.FirstOrDefault(
            x => x.userId == userId && x.videoId == videoId);
    }
}