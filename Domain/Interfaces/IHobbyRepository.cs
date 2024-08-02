using cache_up.Domain.Entities;

namespace cache_up.Domain.Interfaces;

public interface IHobbyRepository
{
    Hobby? GetById(int id);
}
