using BelugaAPI.Application.InputModel;
using BelugaAPI.Core.Entities;
using BelugaAPI.Provider.Providers.Results;

namespace BelugaAPI.Application.Services.Interfaces;

public interface IChatService
{
    Task<Chat?> FetchById(string userId, string video);
    Task<RunResult> AddMessage(MessageInputModel req);
}