using BelugaAPI.Application.InputModel;
using BelugaAPI.Core.Entities;

namespace BelugaAPI.Application.Interfaces;

public interface IVideoService
{
    Task<Video> CreateVideo(VideoInputModel req);
    Task<Video> AddContentToVideo(string videoId, VideoAddContentInputModel req);
    Task<Video> FetchById(string videoId);
    Task<List<Video>> FetchAllByUserId(string userId);
    Task<List<Video>> FetchAll();
}