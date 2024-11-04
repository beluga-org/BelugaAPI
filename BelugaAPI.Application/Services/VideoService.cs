using BelugaAPI.Application.InputModel;
using BelugaAPI.Application.Interfaces;
using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Interfaces;
using BelugaAPI.Persistence.Services.Interfaces;

namespace BelugaAPI.Application.Services;

public class VideoService : IVideoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStorageService _storageService;

    public VideoService(IUnitOfWork unitOfWork, IStorageService storageService)
    {
        _unitOfWork = unitOfWork;
        _storageService = storageService;
    }

    public async Task<Video> CreateVideo(VideoInputModel req)
    {
        try
        {
            
            await _storageService.AddMessage("send-translate", "hello world");
            
            Video video = new Video()
            {

            };

            _unitOfWork.Video.Add(video);
            await _unitOfWork.Complete();
            
            return video;
            //await _unitOfWork.Video.Add()
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}