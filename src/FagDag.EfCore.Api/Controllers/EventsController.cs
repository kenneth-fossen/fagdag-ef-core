using FagDag.EfCore.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FagDag.EfCore.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController(
    [FromServices] ILogger<EventsController> logger,
    [FromServices] IEpicEventsService epicEventsService)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEvents()
    {
        logger.LogInformation("Called => GetEvents");

        var result = await epicEventsService
            .GetAllEventsAsync();

        return Ok(result);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEvent(Guid id)
    {
        logger.LogInformation("Called => GetEvent");

        var result = await epicEventsService.GetEventByIdAsync(id);

        return Ok(result);
    }
}
