using cache_up.Domain.Entities;
using cache_up.Domain.Interfaces;
using cache_up.Domain.Services;
using cache_up.Infrastructure.Cache;
using cache_up.Infrastructure.Repositories;

namespace cache_up;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddMemoryCache();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IRepository<Traveler>, TravelerRepository>();
        builder.Services.AddScoped<IRepository<Hobby>, HobbyRepository>();

        // Decorate all repositories
        builder.Services.Decorate(typeof(IRepository<>), typeof(CachedRepository<>));

        builder.Services.AddScoped<ITravelerService, TravelerService>();
        builder.Services.AddScoped<IHobbyService, HobbyService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
