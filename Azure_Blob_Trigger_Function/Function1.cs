using System;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Azure_Blob_Trigger_Function
{
    public class Function1
    {
        [FunctionName("BlobTrigger")]
        public void Run([BlobTrigger("jdlearningblobcontainer/{name}", Connection = "AzureBlobStorageKey")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=AzureBlobDemo;User Id=sa;Password=123;"))
            {
                conn.Open();

                var insertQuery = $"INSERT INTO [BlobDetails] (FileName,isFileUploaded,DateOfUpdation) VALUES('{name}', '{true}' , '{DateTime.UtcNow}')";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    var rows = cmd.ExecuteNonQuery();
                    log.LogInformation($"{rows} rows were updated");
                }
            }
        }
    }
}
