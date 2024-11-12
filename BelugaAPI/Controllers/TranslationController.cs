using BelugaAPI.Application.InputModel;
using BelugaAPI.Application.Interfaces;
using BelugaAPI.Common.CustomResult;
using Microsoft.AspNetCore.Mvc;

namespace BelugaAPI.controllers;

//TODO: CRIAR A AS ATUALIZAÇÕES E CHECK-UPS PARA A API
//TODO: GET STATUS DO VÍDEO/ TRADUÇÃO
//TODO: SUBIR O CONTENT EM BASE 64 PARA O VIDEO NO SPEECH-TO-TEXT

[Route("api/translation")]
[ApiController]
public class TranslationController : ControllerBase
{
    private readonly ITranslationService _translationService;

    public TranslationController(ITranslationService translationService)
    {
        _translationService = translationService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTranslation(TranslationInputModel req)     
    {
        try
        {
            var translation = await _translationService.CreateTranslation(req);

            return new MyOkResult(translation);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }      
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTranslation(string id, UpdateTranslationInputModel req)     
    {
        try
        {
            var translation = await _translationService.UpdateTranslation(id, req);

            return new MyOkResult(translation);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }      
    
    [HttpGet("{id}")]
    public async Task<IActionResult> FetchById(string id)     
    {
        try
        {
            var translation = await _translationService.FetchById(id);

            return new MyOkResult(translation);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }   
}