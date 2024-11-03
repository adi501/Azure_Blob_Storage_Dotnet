using Azure_Blob_Storage_Dotnet.Models;

namespace Azure_Blob_Storage_Dotnet.Repositories
{
    public interface IBlobStorage
    {
        Task UploadFileAsync(FileDetails fileDetails);
    }
}
