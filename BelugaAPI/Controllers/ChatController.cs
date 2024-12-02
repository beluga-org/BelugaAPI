using BelugaAPI.Application.InputModel;
using BelugaAPI.Common.CustomResult;
using BelugaAPI.Provider.Providers;
using BelugaAPI.Provider.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BelugaAPI.Application.Services.Interfaces;

namespace BelugaAPI.controllers;

[Route("api/chat")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }
    
    [HttpPost("message")]
    public async Task<IActionResult> CreateMessage(MessageInputModel req)     
    {
        try
        {
            var assistant = await _chatService.AddMessage(req);
    
            return new MyOkResult(assistant);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }    
    
    [HttpGet]
    public async Task<IActionResult> FetchChat(string userId, string videoId)     
    {
        try
        {
            var assistant = await _chatService.FetchById(userId, videoId);

            // TODO: RETRIEVE THREAD
            return new MyOkResult(assistant);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }  
}