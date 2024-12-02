using BelugaAPI.Application.InputModel;
using BelugaAPI.Application.Services.Interfaces;
using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Repositories.Interfaces;

namespace BelugaAPI.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User> CreateUser(UserInputModel req)
    {
        try
        {
            User user = new()
            {
                name = req.name,
                email = req.email,
                password = req.password,
                created = DateTime.UtcNow,
                updated = DateTime.UtcNow,
            };
            
            _unitOfWork.User.Add(user);

            await _unitOfWork.Complete();

            return user;
        }            
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<List<User>> FetchAllUsers()
    {
        try
        {
            var users = _unitOfWork.User.GetAll();

            await _unitOfWork.Complete();

            return users.ToList();
        }            
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}