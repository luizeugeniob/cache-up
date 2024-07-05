using cache_up.Domain.Entities;
using cache_up.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace cache_up.Infrastructure.Repositories;

public class TravelerRepository : ITravelerRepository
{
    private static readonly List<Traveler> BankPower =
        [
            new() { Id = 1, Name = "Ana"},
            new() { Id = 2, Name = "Alex"},
            new() { Id = 3, Name = "Anka"},
            new() { Id = 4, Name = "Lia"},
            new() { Id = 5, Name = "Luiz"},
            new() { Id = 6, Name = "Tiago"},
            new() { Id = 7, Name = "Satrio"},
            new() { Id = 8, Name = "Vignesh"}
        ];

    private readonly IMemoryCache _cache;

    public TravelerRepository(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Traveler? GetById(int id)
    {
        // Verify if the cache has value
        if (!_cache.TryGetValue(id, out Traveler? traveler))
        {
            // Let's pretend the database is taking five seconds to respond
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();

            // Get the traveler from the "database"
            traveler = BankPower.FirstOrDefault(bp => bp.Id == id);

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
