using System.Text.Json.Serialization;

namespace Api.Dtos;

public class UserOutDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("firstname")]
    public string Firstname { get; set; }
    [JsonPropertyName("lastname")]
    public string LastName { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
}