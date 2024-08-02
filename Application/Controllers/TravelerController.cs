using cache_up.Domain.Entities;
using cache_up.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cache_up.Application.Controllers;

[ApiController]
[Route("[controller]/")]
public class TravelerController : ControllerBase
{
    private readonly ITravelerService _travelerService;

    public TravelerController(ITravelerService weatherForecastService)
    {
        _travelerService = weatherForecastService;
    }

    [HttpGet("{id}")]
    public Traveler? GetById(int id)
    {
        return _travelerService.GetById(id);
    }
}
