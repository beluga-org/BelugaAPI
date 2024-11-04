using BelugaAPI.Application.InputModel;
using BelugaAPI.Core.Entities;

namespace BelugaAPI.Application.Interfaces;

public interface IVideoService
{
    Task<Video> CreateVideo(VideoInputModel req);
}