using System.ComponentModel.DataAnnotations;

namespace API;

public class RegisterDto
{
    [Required]
    public string UserName { get; set; } = String.Empty;
    [Required]
    public string Password { get; set; } = String.Empty;
}
