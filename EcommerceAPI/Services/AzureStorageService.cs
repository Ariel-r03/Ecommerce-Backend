using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EcommerceAPI.Services.Interfaces;

namespace EcommerceAPI.Services
{
    public class AzureStorageService : IAzureStorageService
    {
        private readonly string _storageConnectionString;
        public AzureStorageService(IConfiguration configuration) 
        {
            _storageConnectionString = configuration.GetValue<string>("AzureStorageConnectionString");
        }
        public Task DeleteAsync(string container, string blobFileName)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadAsync(IFormFile file, string container, string blobName = null)
        {
            if(file.Length == 0)
            {
                return null;
            }

            var containerName = container.ToLower();

            var blolbContainerClient = new BlobContainerClient(_storageConnectionString, containerName);

            if (string.IsNullOrEmpty(blobName))
            {
                blobName = Guid.NewGuid().ToString();
            }

            var blobClient = blolbContainerClient.GetBlobClient(blobName);
            var blobHttpHeader = new BlobHttpHeaders { ContentType = file.ContentType };

            await using (Stream stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, new BlobUploadOptions { HttpHeaders = blobHttpHeader });
            }

            return blobName;
        }
    }
}
