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

    /// <summary>
    /// TODO: Planned API HealthCheck for DB
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult CheckDB()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Planned process to run a seeding job!
    /// </summary>
    /// <returns></returns>
    public IActionResult Seed()
    {
        throw new NotImplementedException();
    }
}