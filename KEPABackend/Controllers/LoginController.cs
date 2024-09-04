using KEPABackend.DTOs.Input;
using KEPABackend.Interfaces.ControllerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace KEPABackend.Controllers;

/// <summary>
/// API Controller für Login
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly ILoginService loginService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="config"></param>
    /// <param name="loginService"></param>
    public LoginController(IConfiguration config, ILoginService loginService)
    {
        _config = config;
        this.loginService = loginService;
    }

    /// <summary>
    /// Login
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    /// <response code="200">Login erfolgreich</response>
    /// <response code="401">Unauthorized</response>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Login loginRequest)
    {
        //TestPW usr01354 <=> 9cc6UIhW8e3BLzlKftn9QvEDjuwQuK9zKN98BPSHJ34=

        string strPWHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(loginRequest.Password)));
        if (await loginService.AreCredentialsCorrectAsync(loginRequest.Username, strPWHash))
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Settings:JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Settings:JWT:ValidIssuer"],
              _config["Settings:JWT:ValidIssuer"],
              null,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
        }
        else
            return Unauthorized();
    }
}