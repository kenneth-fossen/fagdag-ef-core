using FagDag.EfCore.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FagDag.EfCore.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RacesController(
    [FromServices] ILogger<RacesController> logger,
    [FromServices] IEpicEventsService epicEventsService)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRaces()
    {
        logger.LogInformation("Called => GetRaces");

        var result = await epicEventsService
            .GetAllRacesAsync();

        return Ok(result);
    }
}
