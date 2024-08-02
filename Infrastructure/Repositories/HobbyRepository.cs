using cache_up.Domain.Entities;
using cache_up.Domain.Interfaces;

namespace cache_up.Infrastructure.Repositories;

public class HobbyRepository : IHobbyRepository
{
    private static readonly List<Hobby> Hobbies =
        [
            new() { Id = 1, Name = "Read" },
            new() { Id = 2, Name = "Travel" },
            new() { Id = 3, Name = "Sleep" },
            new() { Id = 4, Name = "Play tennis" },
            new() { Id = 5, Name = "Run" },
            new() { Id = 6, Name = "Listen music" },
            new() { Id = 7, Name = "Photography" },
            new() { Id = 8, Name = "Learn languages" }
        ];

    public Hobby? GetById(int id)
    {
        // Let's pretend the database is taking five seconds to respond
        Task.Delay(TimeSpan.FromSeconds(5)).Wait();
        return Hobbies.FirstOrDefault(h => h.Id.Equals(id));
    }
}
