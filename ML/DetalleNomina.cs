using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class DetalleNomina
    {
        public int IdDetalle { get; set; }
        public string? Concepto { get; set; }
        public string? Tipo { get; set; }
        public decimal Monto { get; set; }

        // Relaciones
        public ML.Nomina? Nomina { get; set; }
    }
}
