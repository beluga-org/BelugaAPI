using BelugaAPI.Application.InputModel;
using BelugaAPI.Core.Entities;

namespace BelugaAPI.Application.Interfaces;

public interface IAccessKeyService
{
    Task<AccessKey> CreateAccessKey(AccessKeyInputModel req);
    Task<List<AccessKey>> FetchAccessKeyByUserId(string userId);
    Task<AccessKey> SoftDeleteAccessKey(string id);
}