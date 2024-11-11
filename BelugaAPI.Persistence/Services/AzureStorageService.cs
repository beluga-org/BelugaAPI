using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using BelugaAPI.Persistence.Services.Interfaces;
using BelugaAPI.Persistence.Services.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace BelugaAPI.Persistence.Services;

public class AzureStorageService : IStorageService
{
    private readonly string _connectionString;
    private readonly CloudStorageAccount _cloudStorageAccount;

    public AzureStorageService(IConfiguration configuration)
    {
        _connectionString = "DefaultEndpointsProtocol=https;AccountName=belugastorage;AccountKey=b/pE5hOodG7rXCu9teSlY8jY+Fe7NuoeZWzzd8/HWD2WL37u2toTAZIm0ZtqBA26AVK7p7BYFDpv+AStzPE1Fg==;EndpointSuffix=core.windows.net";
        _cloudStorageAccount = CloudStorageAccount.Parse(_connectionString);
    }
    
    public async Task<CloudBlockBlob> UploadFile(Stream file, string containerName, string fileName, string contentType)
    {
        try
        {
            CloudBlobClient blobClient = _cloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
            
            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(fileName);
                
            blockBlob.Properties.ContentType = contentType;

            await blockBlob.UploadFromStreamAsync(file);

            return blockBlob;
            
            // BlobContainerClient container = new BlobContainerClient(_connectionString, containerName);
            //
            // await container.CreateIfNotExistsAsync();
            //
            // BlobClient blob = container.GetBlobClient(fileName);
            //
            // var blobHttpHeader = new BlobHttpHeaders();
            // blobHttpHeader.ContentType = contentType;
            //
            // await using (var fileStream = new MemoryStream(file))
            // {
            //     var uploadedBlob = await blob.UploadAsync(fileStream, blobHttpHeader);
            // }
            //
            // Uri blobUri = blob.Uri;
            // if (containerName == "midias")
            // {
            //     BlobSasBuilder sasBuilder = new BlobSasBuilder()
            //     {
            //         BlobContainerName = containerName,
            //         BlobName = blob.Name,
            //         Resource = "b",
            //         ExpiresOn = DateTimeOffset.UtcNow.AddDays(8) // Set the expiration time for the SAS
            //     };
            //
            //     // Add the permissions for the SAS
            //     sasBuilder.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.List);
            //
            //     // Generate the SAS token
            //     string sasToken = blob.GenerateSasUri(sasBuilder).ToString();
            //
            //     // The blob URI with the SAS token
            //     blobUri = new Uri(sasToken);
            // }
            //
            // var blobProperties = blob.GetProperties();
            //
            // VideoResult res = new VideoResult()
            // {
            //     Url = blobUri.ToString(),
            //     BlobName = blob.Name,
            //     Metadata = JsonConvert.SerializeObject(blobProperties.Value.Metadata)
            // };
            //
            // return res;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task AddMessage(string queueName, string req)
    {
        try
        {
            // Create the queue client.
            CloudQueueClient queueClient = _cloudStorageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue.
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            // Create the queue if it doesn't already exist.
            // await queue.CreateIfNotExistsAsync();

            // Create a message and add it to the queue.
            CloudQueueMessage message = new CloudQueueMessage(req);
            
            await queue.AddMessageAsync(message);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}