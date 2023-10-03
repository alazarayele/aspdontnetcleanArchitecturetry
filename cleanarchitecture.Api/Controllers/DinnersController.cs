using Microsoft.AspNetCore.Authorization;

namespace cleanarchitecture.Api.Controllers;

[Route("[controller]")]


public class DinnersConroller : ApiController
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}