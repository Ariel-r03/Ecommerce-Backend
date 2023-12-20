namespace EcommerceAPI.Services.Interfaces
{
    public interface IAzureStorageService
    {
        Task<string> UploadAsync(IFormFile file, string container, string blobName = null);

        Task DeleteAsync(string container, string blobFileName);
    }
}
