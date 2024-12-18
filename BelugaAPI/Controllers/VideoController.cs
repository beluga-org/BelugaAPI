using BelugaAPI.Application.InputModel;
using BelugaAPI.Application.Services.Interfaces;
using BelugaAPI.Common.CustomResult;
using Microsoft.AspNetCore.Mvc;

namespace BelugaAPI.controllers;

[Route("api/video")]
[ApiController]
public class VideoController : ControllerBase
{
    private readonly IVideoService _videoService;

    public VideoController(IVideoService videoService)
    {
        _videoService = videoService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateVideo(VideoInputModel req)     
    {
        try
        {
            
            // [HttpPost]
            // public async Task<IActionResult> CreateVideo(        
            //     IFormFile file, 
            //     string originalName, 
            //     string targetLanguage,
            //     string userId)     
            // {
            //     try
            //     {
            //         var req = new VideoInputModel()
            //         {
            //             file = file,
            //             originalLanguage = originalName,
            //             targetLanguage = targetLanguage,
            //             userId = userId
            //         };  
            
            var video = await _videoService.CreateVideo(req);

            return new MyOkResult(video);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }       
    
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> FetchAllVideosByUser(string userId)     
    {
        try
        {
            var video = await _videoService.FetchAllByUserId(userId);
            
            return new MyOkResult(video);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }    
    
    [HttpGet("{id}")]
    public async Task<IActionResult> FetchVideoById(string id)     
    {
        try
        {
            var video = await _videoService.FetchById(id);
            
            return new MyOkResult(video);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    } 
    
    [HttpPut("{id}/content")]
    public async Task<IActionResult> AddContentToVideo(string id, VideoAddAssistantInputModel req)     
    {
        try
        {
            var video = await _videoService.AddContentToVideo(id, req);
            
            return new MyOkResult(video);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}