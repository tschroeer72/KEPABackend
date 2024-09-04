using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Input;

/// <summary>
/// DTO Login
/// </summary>
public class Login
{
    /// <summary>
    /// Loginname
    /// </summary>
    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; } = default!;

    /// <summary>
    /// Passwort
    /// </summary>
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = default!;
}
