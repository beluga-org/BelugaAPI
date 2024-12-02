using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Context;
using BelugaAPI.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;

namespace BelugaAPI.Persistence.Repositories;
public class VideoRepository : Repository<Video>, IVideoRepository
{
    public VideoRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public List<Video> FetchAllByUserId(string userId)
    {
        var queryFilter = _entities
            .Include(x => x.translations)
            .Where(x =>
                x.userId == userId 
                );
            
        queryFilter = queryFilter.AsNoTracking();

        return queryFilter.ToList();
    }

    public Video? FetchById(string id)
    {
        var queryFilter = _entities
            .Include(x => x.translations)
            .Where(x => x.id == id);
        
        queryFilter = queryFilter.AsNoTracking();
        
        return queryFilter.FirstOrDefault();
    }
}
