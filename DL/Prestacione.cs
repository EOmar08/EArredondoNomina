using System;
using System.Collections.Generic;

namespace DL;

public partial class Prestacione
{
    public int IdPrestacion { get; set; }

    public int IdEmpleado { get; set; }

    public int IdTipoPrestacion { get; set; }

    public DateOnly FechaAsignacion { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual TipoPrestacion IdTipoPrestacionNavigation { get; set; } = null!;
}
