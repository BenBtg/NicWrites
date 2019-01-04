using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.MobCAT.Services;
using NicWrites.Models;

namespace NicWrites.Services
{
    public class NicWritesService : BaseHttpService, INicWritesService
    {
        public NicWritesService(string apiBaseAddress, string apiKey = null, HttpMessageHandler handler = null) 
            : base(apiBaseAddress, handler)
        {
            Serializer = new Microsoft.MobCAT.Converters.JsonSerializer();
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
            return GetAsync<List<Document>>($"shortstories", cancellationToken);
        }

        Task<List<Document>> INicWritesService.GetScreenplaysAsync(bool forceRefresh, CancellationToken cancellationToken)
        {
            return GetAsync<List<Document>>($"screenplays", cancellationToken);
        }

        Task<List<Document>> INicWritesService.GetSocialPhotosAsync(bool forceRefresh, CancellationToken cancellationToken)
        {
            return GetAsync<List<Document>>($"socialmedia", cancellationToken);
        }


        /*
        public <IEnumerable<string>>GetSocialPhotosAsync(bool forceRefresh = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            GetAsync<string>() public Task<IEnumerable<string>> GetSocialPhotosAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }
    }

    public Task<Forecast> GetForecastAsync(string city, TemperatureUnit unit = TemperatureUnit.Metric, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException(nameof(city));

            return GetAsync<Forecast>($"forecasts/{city}?units={unit.ToString()}", cancellationToken, SetApiKeyHeader);
        }*/
    }
}
