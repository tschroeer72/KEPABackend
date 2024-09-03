using KEPABackend.DTOs.Input;
using KEPABackend.Interfaces.ControllerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace KEPABackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private IConfiguration _config;
    private readonly ILoginService loginService;

    public LoginController(IConfiguration config, ILoginService loginService)
    {
        _config = config;
        this.loginService = loginService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Login loginRequest)
    {
        //your logic for login process
        //If login usrename and password are correct then proceed to generate token

        //if (loginRequest.Username.Trim().ToLower() == "admin" && loginRequest.Password.Trim().ToLower() == "admin")
        //{

        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Settings:JWT:Secret"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var Sectoken = new JwtSecurityToken(_config["Settings:JWT:ValidIssuer"],
        //      _config["Settings:JWT:ValidIssuer"],
        //      null,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //    var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

        //    return Ok(token);
        //}
        //else
        //    return Unauthorized();

        if(await loginService.AreCredentialsCorrectAsync(loginRequest.Username, loginRequest.Password))
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Settings:JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Settings:JWT:ValidIssuer"],
              _config["Settings:JWT:ValidIssuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
        }
        else
            return Unauthorized();
    }
}