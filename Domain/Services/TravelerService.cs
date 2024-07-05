using cache_up.Domain.Entities;
using cache_up.Domain.Interfaces;

namespace cache_up.Domain.Services;

public class TravelerService : ITravelerService
{
    private readonly ITravelerRepository _travelerRepository;

    public TravelerService(ITravelerRepository travelerRepository)
    {
        _travelerRepository = travelerRepository;
    }

    public Traveler? GetById(int id)
        => _travelerRepository.GetById(id);
}
