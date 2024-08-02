using cache_up.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace cache_up.Infrastructure.Cache
{
    public class CachedRepository<T> : IRepository<T> where T : class
    {
        private readonly IMemoryCache _cache;
        private readonly IRepository<T> _repository;

        public CachedRepository(
            IMemoryCache cache,
            IRepository<T> repository)
        {
            _cache = cache;
            _repository = repository;
        }

        public T? GetById(int id)
        {
            var cacheKey = $"{typeof(T).Name}-{id}";

            // Verify if the cache has value
            if (!_cache.TryGetValue(cacheKey, out T? entity))
            {
                // Get the traveler from the repository, if the cache doesn't exists
                entity = _repository.GetById(id);

                // Store the cache
                if (entity != null)
                {
                    _cache.Set(cacheKey, entity, TimeSpan.FromSeconds(15));
                }
            }

            return entity;
        }
    }
}