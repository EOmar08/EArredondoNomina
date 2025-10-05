using System;
using System.Collections.Generic;

namespace DL;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public string Rfc { get; set; } = null!;

    public string Nss { get; set; } = null!;

    public string Curp { get; set; } = null!;

    public DateOnly FechaIngreso { get; set; }

    public int IdDepartamento { get; set; }

    public decimal SalarioBase { get; set; }

    public int? NoFaltas { get; set; }

    public virtual ICollection<Deduccione> Deducciones { get; set; } = new List<Deduccione>();

    public virtual ICollection<HistorialPermiso> HistorialPermisos { get; set; } = new List<HistorialPermiso>();

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();

    public virtual ICollection<Permiso> PermisoIdAutorizadorNavigations { get; set; } = new List<Permiso>();

    public virtual ICollection<Permiso> PermisoIdEmpleadoNavigations { get; set; } = new List<Permiso>();

    public virtual ICollection<Prestacione> Prestaciones { get; set; } = new List<Prestacione>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
