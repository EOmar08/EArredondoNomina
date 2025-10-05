using System;
using System.Collections.Generic;

namespace DL;

public partial class HistorialPermiso
{
    public int IdHistorialPermiso { get; set; }

    public int IdPermiso { get; set; }

    public DateOnly FechaRevision { get; set; }

    public int IdStatusPermiso { get; set; }

    public string? Observaciones { get; set; }

    public int IdEmpleadoAccion { get; set; }

    public virtual Empleado IdEmpleadoAccionNavigation { get; set; } = null!;

    public virtual Permiso IdPermisoNavigation { get; set; } = null!;

    public virtual StatusPermiso IdStatusPermisoNavigation { get; set; } = null!;
}
