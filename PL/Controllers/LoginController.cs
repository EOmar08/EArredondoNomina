using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        private readonly BL.Login _login;
        private readonly BL.Usuario _usuario;
        public LoginController(BL.Login login, BL.Usuario usuario)
        {
            _login = login;
            _usuario = usuario;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ML.Login Login)
        {
            ML.Result result = _login.GetByEmail(Login);

            if (result.Correct)
            {
                // Generar token
                ML.Usuario usuario = (ML.Usuario)result.Object;
                string token = GenerateJwtToken(usuario);

                // Guardar token en una cookie
                Response.Cookies.Append("AuthToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(30)
                });

                return RedirectToAction("GetAll","Empleado");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult LogOut()
        {
            Response.Cookies.Delete("AuthToken");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]   
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ML.Usuario usuario)
        {
            usuario.PasswordHash = ML.PasswordHasher.HashPassword(usuario.PasswordHash);

            ML.Result result = _usuario.Add(usuario);

            if (result.Correct)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        [NonAction]
        private string GenerateJwtToken(ML.Usuario Usuario)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Role, Usuario.Rol.Descripcion),
            new Claim(ClaimTypes.Name, Usuario.NombreUsuario)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdfghjklñpoiuy7654arser5000054as"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
