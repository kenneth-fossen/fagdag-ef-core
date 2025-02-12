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
    public async Task<IActionResult> GetAllParticipantsAsync()
    {
        logger.LogInformation("Called: GetAllParticipantsAsync ");

        var result = await epicEventsService
            .GetAllParticipantsAsync();

        return Ok(result);
    }
}
