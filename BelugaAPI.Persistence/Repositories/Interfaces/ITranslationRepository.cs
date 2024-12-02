using BelugaAPI.Core.Entities;

namespace BelugaAPI.Persistence.Repositories.Interfaces;

public interface ITranslationRepository : IRepository<Translation>
{
    Translation? FetchById(string id);
}