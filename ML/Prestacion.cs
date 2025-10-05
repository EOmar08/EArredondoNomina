using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Prestacion
    {
        public int IdPrestacion { get; set; }
        public DateTime FechaAsignacion { get; set; }

        // Relaciones
        public ML.Empleado? Empleado { get; set; }
        public ML.TipoPrestacion? TipoPrestacion { get; set; }
    }
}
