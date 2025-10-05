using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class HistorialPermiso
    {
        public int IdHistorialPermiso { get; set; }
        public DateTime FechaRevision { get; set; }
        public string? Observaciones { get; set; }

        // Relaciones
        public ML.Permiso? Permiso { get; set; }
        public ML.StatusPermiso? StatusPermiso { get; set; }
        public ML.Empleado? Empleado { get; set; }
    }
}
