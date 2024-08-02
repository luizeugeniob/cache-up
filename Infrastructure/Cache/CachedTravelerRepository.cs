using cache_up.Domain.Entities;
using cache_up.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace cache_up.Infrastructure.Cache
{
    public class CachedTravelerRepository : ITravelerRepository
    {
        private readonly IMemoryCache _cache;
        private readonly ITravelerRepository _repository;

        public CachedTravelerRepository(
            IMemoryCache cache,
            ITravelerRepository repository)
        {
            _cache = cache;
            _repository = repository;
        }

        public Traveler? GetById(int id)
        {
            // Verify if the cache has value
            if (!_cache.TryGetValue(id, out Traveler? traveler))
            {
                // Get the traveler from the repository, if the cache doesn't exists
                traveler = _repository.GetById(id);

                // Define the cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(5))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                // Store the cache
                if (traveler != null)
                {
                    _cache.Set(id, traveler, cacheEntryOptions);
                }
            }

            return traveler;
        }
    }
}
