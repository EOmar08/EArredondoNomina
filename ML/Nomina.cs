using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Nomina
    {
        public int IdNomina { get; set; }
        public DateTime FechaInicioPago { get; set; }
        public DateTime FechaFinalPago { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal TotalDeducciones { get; set; }
        public decimal SalarioNeto { get; set; }
        public DateTime FechaGeneracion { get; set; }

        // Relaciones
        public ML.Empleado? Empleado { get; set; }
    }
}
