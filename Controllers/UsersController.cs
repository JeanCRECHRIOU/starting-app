using Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController(ILogger<UsersController> _logger) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<UserOutDto>> GetAll()
    {
        return Ok(
            new List<UserOutDto>());
    }
    
    [HttpGet("{id}")]
    public ActionResult<UserOutDto> Get(int id)
    {
        return Ok(
            new UserOutDto());
    }

    [HttpPost]
    public ActionResult<UserOutDto> CreateUser()
    {
        return Ok(
            new UserOutDto());
    }
}