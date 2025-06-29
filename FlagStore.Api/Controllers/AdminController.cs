using FlagStore.Api.Models.Request;
using FlagStorm.Data.Feature;
using FlagStorm.Data.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlagStore.Api.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController(IFeatureService featureService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateFeature(FlagStormFeature flagStormFeature)
    {
        return Ok(await featureService.CreateFeature(flagStormFeature));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeature()
    {
        return Ok();
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetFeature(string id)
    {
        return Ok(await featureService.GetFeature(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFeature(string id, CreateFeatureRequest request)
    {
        return Ok();
    }
    
    
}