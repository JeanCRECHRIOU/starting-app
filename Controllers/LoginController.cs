using Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController(ILogger<UsersController> _logger) : ControllerBase
{

    [HttpPost]
    public ActionResult Login(UserLoginDto  userLoginDto)
    {
        if(!ModelState.IsValid) return BadRequest();
        // Todo get service.GetUserByEmail()
        
      var userOutDto = new UserLoginOutDto()
      {
          Id = 1,
          Email = userLoginDto.Email,
      };
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userLoginDto.Email),
            new Claim(ClaimTypes.NameIdentifier, userOutDto.Id.ToString() ?? string.Empty)
        };
        var identity = new ClaimsIdentity(claims, BearerTokenDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        return SignIn(principal, BearerTokenDefaults.AuthenticationScheme);
    }
    
}