﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Email { get; set; }
        public string? NombreUsuario { get; set; }
        public string? PasswordHash { get; set; }
        public bool Status { get; set; }
        public ML.Empleado? Empleado { get; set; }
        public ML.Rol? Rol { get; set; }


    }
}
