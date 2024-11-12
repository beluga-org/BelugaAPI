using BelugaAPI.Application.InputModel;
using BelugaAPI.Application.Interfaces;
using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Interfaces;

namespace BelugaAPI.Application.Services;

public class TranslationService : ITranslationService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public TranslationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Translation> CreateTranslation(TranslationInputModel req)
    {
        try
        {
            Translation translation = new Translation()
            {
                language = req.language,
                videoId = req.videoId,
                status = req.status,
                subtitleUrl = req.subtitleUrl,
                translationUrl = req.translationUrl,
                created = DateTime.UtcNow,
                updated = DateTime.UtcNow,
            };
            
            _unitOfWork.Translation.Add(translation);
            await _unitOfWork.Complete();

            if (translation == null)
                throw new Exception("Translation not found");
            
            return translation;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<Translation> UpdateTranslation(string id, UpdateTranslationInputModel req)
    {
        try
        {
            var translation = _unitOfWork.Translation.FetchById(id);
            
            if (translation == null)
                throw new Exception("Translation not found");

            translation.subtitleUrl = req.subtitleUrl ?? translation.subtitleUrl;
            translation.translationUrl = req.translationUrl ?? translation.translationUrl;
            translation.status = req.status ?? translation.status;
            translation.language = req.language ?? translation.language;
            translation.videoId = req.videoId ?? translation.videoId;
            translation.updated = DateTime.UtcNow;
            
            _unitOfWork.Translation.Update(translation);
            await _unitOfWork.Complete();
            
            return translation;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<Translation> FetchById(string translationId)
    {
        try
        {
            var translation = _unitOfWork.Translation.FetchById(translationId);
            await _unitOfWork.Complete();

            if (translation == null)
                throw new Exception("Translation not found");
            
            return translation;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}