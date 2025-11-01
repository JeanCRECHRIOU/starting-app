using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Dtos;

public class UserLoginDto
{
    [Required]
    [FromQuery(Name = "email")]
    public string Email { get; set; }
    
    [FromQuery(Name = "password")]
    [Required]
    public string Password { get; set; }
}