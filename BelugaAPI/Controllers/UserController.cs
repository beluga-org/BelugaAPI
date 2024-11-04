using BelugaAPI.Application.InputModel;
using BelugaAPI.Application.Interfaces;
using BelugaAPI.Common.CustomResult;
using Microsoft.AspNetCore.Mvc;

namespace BelugaAPI.controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUsers()     
    {
        try
        {
            var users = await _userService.FetchAllUsers();

            return new MyOkResult(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserInputModel req)
    {
        try
        {
            var user = await _userService.CreateUser(req);

            return new MyOkResult(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
