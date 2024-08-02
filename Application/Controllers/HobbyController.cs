using cache_up.Domain.Entities;
using cache_up.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cache_up.Application.Controllers;

[ApiController]
[Route("[controller]/")]
public class HobbyController : ControllerBase
{
    private readonly IHobbyService _hobbyService;

    public HobbyController(IHobbyService hobbyService)
    {
        _hobbyService = hobbyService;
    }

    [HttpGet("{id}")]
    public Hobby? GetById(int id)
    {
        return _hobbyService.GetById(id);
    }
}
