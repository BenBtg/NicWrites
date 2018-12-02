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
            Serializer = new Microsoft.MobCAT.Converters.XmlSerializer();
        }

        public Task<EnumerationResults> GetSocialPhotosAsync(bool forceRefresh = false, CancellationToken cancellationToken = default(CancellationToken))
        {
           return GetAsync<EnumerationResults>($"nicwritescontainer/?comp=list", cancellationToken);
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
