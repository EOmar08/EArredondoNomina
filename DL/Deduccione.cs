using System;
using System.Collections.Generic;

namespace DL;

public partial class Deduccione
{
    public int IdDeduccion { get; set; }

    public int IdEmpleado { get; set; }

    public int IdTipoDeduccion { get; set; }

    public DateOnly FechaAsignacion { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual TipoDeduccion IdTipoDeduccionNavigation { get; set; } = null!;
}
