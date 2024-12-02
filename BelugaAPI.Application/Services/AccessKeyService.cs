using BelugaAPI.Application.InputModel;
using BelugaAPI.Application.Services.Interfaces;
using BelugaAPI.Application.Utils;
using BelugaAPI.Core.Entities;
using BelugaAPI.Persistence.Repositories.Interfaces;
using BelugaAPI.Persistence.Repositories;

namespace BelugaAPI.Application.Services;

public class AccessKeyService : IAccessKeyService
{
    private readonly IUnitOfWork _unitOfWork;

    public AccessKeyService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<AccessKey> CreateAccessKey(AccessKeyInputModel req)
    {
        try
        {
            AccessKey accessKey = new AccessKey()
            {
                key = TokenGenerator.GenerateToken(),
                userId = req.userId,
                created = DateTime.UtcNow,
                updated = DateTime.UtcNow,
            };
            
            _unitOfWork.AccessKey.Add(accessKey);
            
            await _unitOfWork.Complete();

            return accessKey;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<List<AccessKey>> FetchAccessKeyByUserId(string userId)
    {
        try
        {
            var accessKey = _unitOfWork.AccessKey.FetchAllByUserId(userId);

            await _unitOfWork.Complete();
            
            return accessKey;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<AccessKey> SoftDeleteAccessKey(string id)
    {
        try
        {
            var accessKey = _unitOfWork.AccessKey.FetchById(id);

            if (accessKey == null)
                throw new Exception("Access key not found");

            accessKey.deleted = DateTime.UtcNow;
            
            _unitOfWork.AccessKey.Update(accessKey);
            
            await _unitOfWork.Complete();

            return accessKey;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}