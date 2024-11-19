using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionAppBlobProject
{
    public class BlobFunctionReceiver
    {
        private readonly ILogger<BlobFunctionReceiver> _logger;

        public BlobFunctionReceiver(ILogger<BlobFunctionReceiver> logger)
        {
            _logger = logger;
        }

        [Function(nameof(BlobFunctionReceiver))]
        public async Task Run([BlobTrigger("samples-workitems/{name}", Connection = "AzureWebJobsStorage")] Stream stream, string name)
        {
            var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
