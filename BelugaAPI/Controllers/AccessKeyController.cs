using System.Web.WebPages;
using BelugaAPI.Application.InputModel;
using BelugaAPI.Application.Services.Interfaces;
using BelugaAPI.Common.CustomResult;
using Microsoft.AspNetCore.Mvc;

namespace BelugaAPI.controllers;

[Route("api/access_key")]
[ApiController]
public class AccessKeyController : ControllerBase
{
    private readonly IAccessKeyService _accessKeyService;

    public AccessKeyController(IAccessKeyService accessKeyService)
    {
        _accessKeyService = accessKeyService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AccessKeyInputModel req)
    {
        try
        {
            var accessKey = await _accessKeyService.CreateAccessKey(req);

            return new MyOkResult(accessKey);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> FetchAllByUserId(string userId)     
    {
        try
        {
            var accessKeys = await _accessKeyService.FetchAccessKeyByUserId(userId);

            return new MyOkResult(accessKeys);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)     
    {
        try
        {
            var accessKey = await _accessKeyService.SoftDeleteAccessKey(id);

            return new MyOkResult(accessKey);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}