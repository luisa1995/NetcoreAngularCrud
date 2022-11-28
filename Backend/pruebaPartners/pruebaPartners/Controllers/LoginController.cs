using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pruebaPartners.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using pruebaPartners.DataContext;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    readonly UsuariosContext UsuarDetails;
    public LoginController(UsuariosContext usuariosContext)
    {
        UsuarDetails = usuariosContext;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Usuarios usuario)
    {

        var data = UsuarDetails.Usuarios.Where(a => a.Usuario == usuario.Usuario).FirstOrDefault();
        if (data is not null)
        {
            if (string.IsNullOrEmpty(data.Usuario))
            {
                return BadRequest("Contraseña o Usuario Invalido");
            }
        }
        else
        {
            return BadRequest("Usuario no existe");
        }
        if (usuario.Usuario == data.Usuario && usuario.Password == data.Password)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:7291",
                audience: "https://localhost:7291",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return Ok(new AuthenticatedResponse { Token = tokenString });
        }

        return Unauthorized();
    }
}