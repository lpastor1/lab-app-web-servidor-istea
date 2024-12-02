using lab_app_web_servidor_istea.DTO;
using lab_app_web_servidor_istea.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lab_app_web_servidor_istea.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController(IConfiguration configuration, IEmpleadoService empleadoService) : ControllerBase
  {
    private IConfiguration _configuration = configuration;

    private readonly IEmpleadoService _empleadoService = empleadoService;

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<object>> Login(LoginRequestDTO login)
    {
      var userEntity = await _empleadoService.GetEmpleadoByUsuarioPass(login.Username, login.Password);
      if (userEntity != null)
      {
        var claims = new[]
        {
          new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
          new Claim(ClaimTypes.Role, userEntity.Rol)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signIn);

        await _empleadoService.RegistrarLogin(userEntity.Id);

        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
      }
      else
      {
        return Unauthorized("Credenciales inválidas");
      }

    }
  }
}
