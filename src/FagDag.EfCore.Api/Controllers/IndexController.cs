using Microsoft.AspNetCore.Mvc;

namespace FagDag.EfCore.Api.Controllers;

[Route("/")]
[ApiExplorerSettings(IgnoreApi = true)]
public class IndexController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Redirect("/scalar/v1");
    }
}
