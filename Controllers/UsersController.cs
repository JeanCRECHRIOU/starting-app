using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(ILogger<UsersController> _logger) : ControllerBase
{
    [HttpGet(Name = "all")]
    public IActionResult GetAll()
    {
        throw new Exception();
        //return Ok("All Users");
    }
}