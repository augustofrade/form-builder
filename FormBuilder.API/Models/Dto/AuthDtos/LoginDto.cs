using System.ComponentModel.DataAnnotations;

namespace FormBuilder.API.Models.Dto.AuthDtos;

public class LoginDto
{
    [Required(ErrorMessage = "Username is required")]
    [MaxLength(40, ErrorMessage = "Username cannot exceed 40 characters")]
    public string Username { get; init; } = string.Empty;
    
    [Required(ErrorMessage = "Password is required")]
    [MaxLength(40, ErrorMessage = "Password cannot exceed 40 characters")]
    public string Password { get; init; } = string.Empty;
}