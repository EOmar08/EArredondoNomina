using System;
using System.Collections.Generic;

namespace DL;

public partial class Nomina
{
    public int IdNomina { get; set; }

    public int IdEmpleado { get; set; }

    public DateOnly FechaInicioPago { get; set; }

    public DateOnly FechaFinalPago { get; set; }

    public decimal SalarioBruto { get; set; }

    public decimal TotalDeducciones { get; set; }

    public decimal SalarioNeto { get; set; }

    public DateOnly FechaGeneracion { get; set; }

    public virtual ICollection<DetalleNomina> DetalleNominas { get; set; } = new List<DetalleNomina>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
