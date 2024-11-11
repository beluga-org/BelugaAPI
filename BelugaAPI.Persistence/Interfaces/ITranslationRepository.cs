using BelugaAPI.Core.Entities;

namespace BelugaAPI.Persistence.Interfaces;

public interface ITranslationRepository : IRepository<Translation>
{
    Translation? FetchById(string id);
}