using BelugaAPI.Application.InputModel;
using BelugaAPI.Application.Interfaces;
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
            var video = await _videoService.CreateVideo(req);

            return new MyOkResult(video);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}