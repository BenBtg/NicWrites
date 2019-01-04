using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NicWrites.Models;

namespace NicWrites.Services
{
    public interface INicWritesService
    {
        Task<List<Document>> GetArticlesAsync(bool forceRefresh = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<Document>> GetSocialPhotosAsync(bool forceRefresh = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<Document>> GetScreenplaysAsync(bool forceRefresh = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<Document>> GetScriptsAsync(bool forceRefresh = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<Document>> GetPromoCopyAsync(bool forceRefresh = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<Document>> GetReviewsAsync(bool forceRefresh = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<Document>> GetShortStoriesAsync(bool forceRefresh = false, CancellationToken cancellationToken = default(CancellationToken));
    }
}
