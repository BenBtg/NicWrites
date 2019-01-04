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
        [FunctionName("GetArticles")]
        public static async Task<IActionResult> GetArticles(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "articles")] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var docs = await BlobHelper.GetBlobsFromContainer("articles",log);

            return docs != null
                ? (ActionResult)new OkObjectResult(docs)
                : new BadRequestObjectResult("Could not find story blobs");
        }

        [FunctionName("GetPromoCopy")]
        public static async Task<IActionResult> GetPromoCopy(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "promocopy")] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var docs = await BlobHelper.GetBlobsFromContainer("promocopy",log);

            return docs != null
                ? (ActionResult)new OkObjectResult(docs)
                : new BadRequestObjectResult("Could not find story blobs");
        }

        [FunctionName("GetReviews")]
        public static async Task<IActionResult> GetReviews(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "reviews")] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var docs = await BlobHelper.GetBlobsFromContainer("reviews",log);

            return docs != null
                ? (ActionResult)new OkObjectResult(docs)
                : new BadRequestObjectResult("Could not find review blobs");
        }

        [FunctionName("GetScripts")]
        public static async Task<IActionResult> GetScripts(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "scripts")] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var docs = await BlobHelper.GetBlobsFromContainer("playscripts",log);

            return docs != null
                ? (ActionResult)new OkObjectResult(docs)
                : new BadRequestObjectResult("Could not find scripts blobs");
        }

        
        [FunctionName("GetShortStories")]
        public static async Task<IActionResult> GetShortStories(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "stories")] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var blobs = await BlobHelper.GetBlobsFromContainer("shortstories", log);

            return blobs != null
                ? (ActionResult)new OkObjectResult(blobs)
                : new BadRequestObjectResult("Could not find story blobs");
        }

        
        [FunctionName("GetScreenplays")]
        public static async Task<IActionResult> GetScreenplays(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "screenplays")] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var storys = await BlobHelper.GetBlobsFromContainer("screenplays",log);

            return storys != null
                ? (ActionResult)new OkObjectResult(storys)
                : new BadRequestObjectResult("Could not find story blobs");
        }

        [FunctionName("GetSocialPosts")]
        public static async Task<IActionResult> GetSocialMedia(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "socialmedia")] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var storys = await BlobHelper.GetBlobsFromContainer("socialmedia",log);

            return storys != null
                ? (ActionResult)new OkObjectResult(storys)
                : new BadRequestObjectResult("Could not find social media blobs");
        }


    }
}
