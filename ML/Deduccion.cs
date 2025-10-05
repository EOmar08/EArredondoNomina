using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Deduccion
    {
        public int IdDeduccion { get; set; }
        public DateTime FechaAsignacion { get; set; }

        // Relaciones
        public ML.Empleado? Empleado { get; set; }
        public ML.TipoDeduccion? TipoDeduccion { get; set; }
    }
}
