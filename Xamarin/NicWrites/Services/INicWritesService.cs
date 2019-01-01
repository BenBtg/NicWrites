using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NicWrites.Models;

namespace NicWrites.Services
{
    public interface INicWritesService
    {
        Task<List<Story>> GetSocialPhotosAsync(bool forceRefresh = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<Story>> GetScreenplaysAsync(bool forceRefresh = false, CancellationToken cancellationToken = default(CancellationToken));
    }
}
