using BelugaAPI.Core.Entities;

namespace BelugaAPI.Persistence.Interfaces;

public interface IVideoRepository : IRepository<Video>
{
    Video? FetchById(string id);
    List<Video> FetchAllByUserId(string userId);
}