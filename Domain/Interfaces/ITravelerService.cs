using cache_up.Domain.Entities;

namespace cache_up.Domain.Interfaces;

public interface ITravelerService
{
    Traveler? GetById(int id);
}
