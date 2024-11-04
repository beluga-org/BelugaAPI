using BelugaAPI.Application.InputModel;
using BelugaAPI.Core.Entities;

namespace BelugaAPI.Application.Interfaces;

public interface IUserService
{
    Task<User> CreateUser(UserInputModel req);
    Task<List<User>> FetchAllUsers();
}