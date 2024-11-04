using BelugaAPI.Persistence.Services.Results;

namespace BelugaAPI.Persistence.Services.Interfaces;

public interface IStorageService
{
    Task<VideoResult> UploadFile(byte[] file, string containerName, string fileName, string contentType);
    // Task<string> GetImageUrl(string containerName, string blobName);
    // Task AddMessageToQueueAsync(string queueName, string message);
    Task AddMessage(string queueName, string message);
}