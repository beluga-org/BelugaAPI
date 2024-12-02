using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Context;
using BelugaAPI.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BelugaAPI.Persistence.Repositories;

public class TranslationRepository : Repository<Translation>, ITranslationRepository
{
    public TranslationRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public Translation? FetchById(string id)
    {
        var queryFilter = _entities
            .AsNoTracking();

        return queryFilter.FirstOrDefault(x => x.id == id);
    }
}