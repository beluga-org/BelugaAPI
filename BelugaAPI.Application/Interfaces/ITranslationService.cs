using BelugaAPI.Application.InputModel;
using BelugaAPI.Core.Entities;

namespace BelugaAPI.Application.Interfaces;

public interface ITranslationService
{
    Task<Translation> CreateTranslation(TranslationInputModel req);
    Task<Translation> UpdateTranslation(string translationId, UpdateTranslationInputModel req);
    Task<Translation> FetchById(string translationId);
}