using cache_up.Domain.Entities;
using cache_up.Domain.Interfaces;

namespace cache_up.Domain.Services;

public class HobbyService : IHobbyService
{
    private readonly IRepository<Hobby> _hobbyRepository;

    public HobbyService(IRepository<Hobby> hobbyRepository)
    {
        _hobbyRepository = hobbyRepository;
    }

    public Hobby? GetById(int id)
        => _hobbyRepository.GetById(id);
}
