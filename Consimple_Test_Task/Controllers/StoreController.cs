using Consimple_Test_Task.Core;
using Consimple_Test_Task.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consimple_Test_Task.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _service;

    public StoreController(IStoreService service)
    {
        _service = service;
    }

    [HttpGet("birthdays")]
    public async Task<IActionResult> GetBirthdayClients([FromQuery] string date)
    {
        if (!DateTime.TryParse(date, out var parsedDate))
        {
            return BadRequest("Invalid date format. Use yyyy-MM-dd.");
        }

        var clients = await _service.GetBirthdayClientsAsync(parsedDate);
        return Ok(clients);
    }

    [HttpGet("recent-buyers")]
    public async Task<IActionResult> GetRecentBuyers([FromQuery] int days)
    {
        var buyers = await _service.GetRecentBuyersAsync(days);
        return Ok(buyers);
    }

    [HttpGet("popular-categories/{clientId}")]
    public async Task<IActionResult> GetPopularCategories([FromRoute] int clientId)
    {
        var categories = await _service.GetPopularCategoriesAsync(clientId);
        return Ok(categories);
    }
}