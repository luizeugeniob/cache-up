using cache_up.Domain.Entities;
using cache_up.Domain.Interfaces;

namespace cache_up.Domain.Services;

public class TravelerService : ITravelerService
{
    private readonly IRepository<Traveler> _travelerRepository;

    public TravelerService(IRepository<Traveler> travelerRepository)
    {
        _travelerRepository = travelerRepository;
    }

    public Traveler? GetById(int id)
        => _travelerRepository.GetById(id);
}
