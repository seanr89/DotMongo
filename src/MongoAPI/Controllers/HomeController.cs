using Microsoft.AspNetCore.Mvc;

namespace MongoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Alive");
    }
}