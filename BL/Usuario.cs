using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        private readonly DL.ProyectoNominaContext _context; 
        public Usuario(DL.ProyectoNominaContext context)
        {
            _context = context;
        }

        public ML.Result Add(ML.Usuario Usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                DL.Usuario usuarioDL = new DL.Usuario();
                usuarioDL.Email = Usuario.Email;
                usuarioDL.NombreUsuario = Usuario.NombreUsuario;
                usuarioDL.PasswordHash = Usuario.PasswordHash;
                usuarioDL.Status = Usuario.Status;
                usuarioDL.IdEmpleado = Usuario.Empleado.IdEmpleado;
                usuarioDL.IdRol = Usuario.Rol.IdRol;

                _context.Usuarios.Add(usuarioDL);

                int rowsAffected = _context.SaveChanges();

                if (rowsAffected > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se insertó el usuario";
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }

    }
}
