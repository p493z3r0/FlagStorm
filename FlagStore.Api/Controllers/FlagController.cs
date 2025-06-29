using FlagStorm.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace FlagStore.Api.Controllers;

[ApiController]
[Route("api/flag")]
public class FlagController : ControllerBase
{
    [HttpPost("")]
    public Task<IActionResult> GetFlags(Actor actor)
    {
        return Task.FromResult<IActionResult>(Ok(new List<string>()));
    }
    
}