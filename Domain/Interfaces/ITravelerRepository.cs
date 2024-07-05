using cache_up.Domain.Entities;

namespace cache_up.Domain.Interfaces;

public interface ITravelerRepository
{
    Traveler? GetById(int id);
}
