using cache_up.Domain.Entities;
using cache_up.Domain.Interfaces;

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

    public Traveler? GetById(int id)
    {
        // Let's pretend the database is taking five seconds to respond
        Task.Delay(TimeSpan.FromSeconds(5)).Wait();
        return BankPower.FirstOrDefault(bp => bp.Id.Equals(id));
    }
}
