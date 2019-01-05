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
    public class NicWritesBlobService : BaseHttpService, INicWritesBlobService
    {
        public NicWritesBlobService(string apiBaseAddress, string apiKey = null, HttpMessageHandler handler = null)
            : base(apiBaseAddress, handler)
        {

        }

        public Task<string> GetDocContentAsync(string url, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetAsync<string>(url, cancellationToken, null, false);
        }
    }
}
