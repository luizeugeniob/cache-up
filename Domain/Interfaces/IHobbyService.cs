using cache_up.Domain.Entities;

namespace cache_up.Domain.Interfaces;

public interface IHobbyService
{
    Hobby? GetById(int id);
}