using System.Text.Json;
using BelugaAPI.Application.InputModel;
using BelugaAPI.Application.Interfaces;
using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Interfaces;
using BelugaAPI.Persistence.Services.Interfaces;
using BelugaAPI.Persistence.Services.Requests;

namespace BelugaAPI.Application.Services;

public class VideoService : IVideoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStorageService _storageService;

    public VideoService(
        IUnitOfWork unitOfWork, 
        IStorageService storageService
        )
    {
        _unitOfWork = unitOfWork;
        _storageService = storageService;
    }

    public async Task<Video> CreateVideo(VideoInputModel req)
    {
        try
        {
            if (req.file.ContentType != "video/mp4")
            {
                throw new InvalidOperationException("This file format is not valid. Use .mp4");
            }
            
            var videoId = Guid.NewGuid().ToString();

            using (var stream = req.file.OpenReadStream())
            {
                var blockBlob = await _storageService.UploadFile(stream, "originals", videoId, "video/mp4");
                
                Video video = new Video()
                {
                    id = videoId,
                    originalName = req.file.FileName,
                    originalLanguage = req.originalLanguage,
                    originalUrl = blockBlob.Uri.ToString(),
                    userId = req.userId,
                    created = DateTime.UtcNow,
                    updated = DateTime.UtcNow,
                };
                
                _unitOfWork.Video.Add(video);
                await _unitOfWork.Complete();
    
     
                // CRIAR TRANSLATION NO BLOB
                SendVideoTranslationRequest translationRequest = new SendVideoTranslationRequest()
                {
                    VideoId = videoId,
                    OriginLanguage = req.originalLanguage,
                    TargetLanguage = req.targetLanguage,
                    HasTranscription = false,
                };
                
                await _storageService.AddMessage("send-translate", JsonSerializer.Serialize(translationRequest));
                
                return video;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Video> AddContentToVideo(string videoId, VideoAddContentInputModel req)
    {
        try
        {
            var video = _unitOfWork.Video.FetchById(videoId);
            

            if (video == null)
                throw new Exception("Video not found");

            video.content = req.content;
            video.updated = DateTime.UtcNow;

            _unitOfWork.Video.Update(video);
            await _unitOfWork.Complete();
            
            return video;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Video>> FetchAll()
    {
        var videos = _unitOfWork.Video.GetAll().ToList();
        await _unitOfWork.Complete();

        return videos;
    }    
    
    public async Task<List<Video>> FetchAllByUserId(string userId)
    {
        var videos = _unitOfWork.Video.FetchAllByUserId(userId);
        await _unitOfWork.Complete();

        return videos;
    }    
    
    public async Task<Video> FetchById(string videoId)
    {
        var video = _unitOfWork.Video.FetchById(videoId);
        await _unitOfWork.Complete();

        if (video == null)
            throw new Exception("Video not found");

        return video;
    }
}