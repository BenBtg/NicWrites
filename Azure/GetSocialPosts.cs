using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace NicWrites
{
    public static class NicWritesApi
    {
        [FunctionName("GetSocialPosts")]
        public static async Task<IActionResult> GetSocialPosts(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "social")] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var storys = await BlobHelper.GetBlobsFromContainer("social-blobs",log);

            var response = JsonConvert.SerializeObject(storys);

            return response != null
                ? (ActionResult)new OkObjectResult(response)
                : new BadRequestObjectResult("Could not find story blobs");
        }

        [FunctionName("GetScreenplays")]
        public static async Task<IActionResult> GetScreenplays(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "screenplays")] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var storys = await BlobHelper.GetBlobsFromContainer("screenplay-blobs",log);

            var response = JsonConvert.SerializeObject(storys);

            return response != null
                ? (ActionResult)new OkObjectResult(response)
                : new BadRequestObjectResult("Could not find story blobs");
        }

        [FunctionName("GetShortStories")]
        public static async Task<IActionResult> GetShortStories(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "stories")] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var blobs = await BlobHelper.GetBlobsFromContainer("shortstory-blobs",log);

            var response = JsonConvert.SerializeObject(blobs);

            return response != null
                ? (ActionResult)new OkObjectResult(response)
                : new BadRequestObjectResult("Could not find story blobs");
        }
    }
}
