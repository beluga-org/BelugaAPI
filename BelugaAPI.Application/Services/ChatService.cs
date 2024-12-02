using BelugaAPI.Application.InputModel;
using BelugaAPI.Application.Services.Interfaces;
using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Repositories.Interfaces;
using BelugaAPI.Provider.Providers.Interfaces;
using BelugaAPI.Provider.Providers.Results;

namespace BelugaAPI.Application.Services;

public class ChatService : IChatService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAssistantService _assistantService;

    public ChatService(IUnitOfWork unitOfWork, IAssistantService assistantService)
    {
        _unitOfWork = unitOfWork;
        _assistantService = assistantService;
    }

    public async Task<Chat?> FetchById(string userId, string videoId)
    {
        try
        {
            var chat = _unitOfWork.Chat.FetchById(userId, videoId);
            await _unitOfWork.Complete();
            
            return chat;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<RunResult> AddMessage(MessageInputModel req)
    {
        try
        {
            var video = _unitOfWork.Video.FetchById(req.videoId);

            if (video?.assistantExternalId == null)
                throw new Exception("This video does not have a assistant");
            
            var chat = _unitOfWork.Chat.FetchById(req.userId, req.videoId);

            if (chat == null)
            {
                var thread = await _assistantService.CreateThread();
                
                Chat chatReq = new Chat()
                {
                    threadId = thread.id,
                    userId = req.userId,
                    videoId = req.videoId,
                    created = DateTime.UtcNow,
                    updated = DateTime.UtcNow,
                };

                _unitOfWork.Chat.Add(chatReq);
                await _unitOfWork.Complete();

                await _assistantService.AddMessage(thread.id, req.message);

                return await _assistantService.CreateRun(thread.id, video.assistantExternalId);
            }
            
            await _assistantService.AddMessage(chat.threadId, req.message);
            
            return await _assistantService.CreateRun(chat.threadId, video.assistantExternalId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}