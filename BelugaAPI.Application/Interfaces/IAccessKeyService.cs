using BelugaAPI.Application.InputModel;
using BelugaAPI.Core.Entities;

namespace BelugaAPI.Application.Interfaces;

public interface IAccessKeyService
{
    Task<AccessKey> CreateAccessKey(AccessKeyInputModel req);
    Task<List<AccessKey>> FetchAccessKeyByUserId(int userId);
    Task<AccessKey> SoftDeleteAccessKey(int id);
}