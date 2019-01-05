using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NicWrites.Models;

namespace NicWrites.Services
{
    public interface INicWritesBlobService
    {
        Task<string> GetDocContentAsync(string url, CancellationToken cancellationToken = default(CancellationToken));
    }
}
