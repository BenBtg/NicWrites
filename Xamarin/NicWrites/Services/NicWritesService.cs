using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.MobCAT.Converters;
using Microsoft.MobCAT.Services;
using NicWrites.Models;

namespace NicWrites.Services
{
    public class NicWritesService : BaseHttpService, INicWritesService
    {
        public NicWritesService(string apiBaseAddress, string apiKey = null, HttpMessageHandler handler = null) 
            : base(apiBaseAddress, handler)
        {
        }

        public Task<List<Document>> GetArticlesAsync(bool forceRefresh = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetAsync<List<Document>>($"articles", cancellationToken);
        }

        public Task<List<Document>> GetPromoCopyAsync(bool forceRefresh, CancellationToken cancellationToken)
        {
            return GetAsync<List<Document>>($"promocopy", cancellationToken);
        }

        public Task<List<Document>> GetReviewsAsync(bool forceRefresh, CancellationToken cancellationToken)
        {
            return GetAsync<List<Document>>($"reviews", cancellationToken);
        }

        public Task<List<Document>> GetScriptsAsync(bool forceRefresh, CancellationToken cancellationToken)
        {
            return GetAsync<List<Document>>($"scripts", cancellationToken);
        }

        public Task<List<Document>> GetShortStoriesAsync(bool forceRefresh, CancellationToken cancellationToken)
        {
            return GetAsync<List<Document>>($"stories", cancellationToken);
        }

        public Task<List<Document>> GetScreenplaysAsync(bool forceRefresh, CancellationToken cancellationToken)
        {
            return GetAsync<List<Document>>($"screenplays", cancellationToken);
        }

        public Task<List<Document>> GetSocialPhotosAsync(bool forceRefresh, CancellationToken cancellationToken)
        {
            return GetAsync<List<Document>>($"socialmedia", cancellationToken);
        }
    }
}
