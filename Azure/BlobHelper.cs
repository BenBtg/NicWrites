using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace NicWrites
{
    public static class BlobHelper
    {
        public static async Task<List<Story>> GetBlobsFromContainer(string containerName, ILogger log)
        {
            if (string.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentException("Invalid container name", nameof(containerName));
            }

            var blobClient = GetBlobClient(log);
            List<Story> storys = new List<Story>();
            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            var blobs = container.ListBlobsSegmentedAsync("", false, BlobListingDetails.Metadata, 50, null, null, null).Result;
            foreach (IListBlobItem item in blobs.Results)
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    //string story = blob.; //await blob.DownloadTextAsync();
                    await blob.GetAccountPropertiesAsync();
                    string title;
                    blob.Metadata.TryGetValue("title", out title);
                    
                    var story = new Story() { Title = title, Url = blob.Uri};
                    
                    // Don't download social images
                    if (containerName != "social-blobs")
                    {
                        story.Content = await blob.DownloadTextAsync();
                    }

                    storys.Add(story);
                }
            }

            return storys;
        }

        public static CloudBlobClient GetBlobClient(ILogger log)
        {
            log.LogInformation("Getting Blob Client");
            var config = new ConfigurationBuilder()
             .SetBasePath(Environment.CurrentDirectory)
             .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
             .AddEnvironmentVariables()
             .Build();

            var connectionString = config["NicWritesBlobConnection"];
            log.LogInformation("Connection string: " + connectionString);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient;
        }
    }
}