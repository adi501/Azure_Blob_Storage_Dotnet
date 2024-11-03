using Azure_Blob_Storage_Dotnet.Models;
using Azure_Blob_Storage_Dotnet.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure_Blob_Storage_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IBlobStorage _blobService;

        public FilesController(IBlobStorage blobService)
        {
            _blobService = blobService;
        }

        /// <summary>
        /// upload file
        /// </summary>
        /// <param name="fileDetail"></param>
        /// <returns></returns>
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFile([FromForm] FileDetails fileDetail)
        {
            if (fileDetail.file != null)
            {
                await _blobService.UploadFileAsync(fileDetail);
            }
            return Ok();
        }
    }
}
