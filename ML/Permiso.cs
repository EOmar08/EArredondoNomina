using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Permiso
    {
        public int IdPermiso { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }

        // Relaciones
        public ML.Empleado? Empleado { get; set; }
        public ML.Empleado? Autorizador { get; set; }
        public ML.StatusPermiso? StatusPermiso { get; set; }
    }
}
