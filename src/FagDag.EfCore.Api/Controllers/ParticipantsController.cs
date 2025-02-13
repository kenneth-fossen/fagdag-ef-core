using FagDag.EfCore.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FagDag.EfCore.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ParticipantsController(
    ILogger<ParticipantsController> logger,
    IEpicEventsService epicEventsService)
    : ControllerBase
{
    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllParticipantsAsync()
    {
        logger.LogInformation("Called: GetAllParticipantsAsync ");

        var result = await epicEventsService
            .GetAllParticipantsAsync();

        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetParticipantsAsync([FromRoute] int id)
    {
        logger.LogInformation("Called: GetParticipantsAsync ");
        var result = await epicEventsService.GetParticipantByIdAsync(id);
        return Ok(result);
    }
}
