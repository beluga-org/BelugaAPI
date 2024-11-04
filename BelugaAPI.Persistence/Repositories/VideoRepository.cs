using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Context;
using BelugaAPI.Persistence.Interfaces;

namespace BelugaAPI.Persistence.Repositories;
public class VideoRepository : Repository<Video>, IVideoRepository
{
    public VideoRepository(ApplicationDbContext context) : base(context)
    {
        
    }
}