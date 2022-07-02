using Microsoft.AspNetCore.Mvc;

namespace MongoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    public UserController(ILogger<UserController> logger)
    {
        this._logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        throw new NotImplementedException();
    }
}