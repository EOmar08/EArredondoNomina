using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Login
    {
        private readonly DL.ProyectoNominaContext _context;
        public Login(DL.ProyectoNominaContext context)
        {
            _context = context;
        }

        public ML.Result GetByEmail(ML.Login login)
        {
            ML.Result result = new ML.Result();
            try
            {

                var loginUser = _context.LoginDTO.FromSqlRaw($"Login '{login.Email}'").AsEnumerable().SingleOrDefault();
                if (loginUser != null)
                {
                    if(ML.PasswordHasher.VerifyPassword(login.Password, loginUser.PasswordHash))
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.NombreUsuario = loginUser.NombreUsuario;
                        usuario.Status = loginUser.Status;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.Descripcion = loginUser.NombreRol;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El password o email no coinciden";
                    }
                    

                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró el usuario.";
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
