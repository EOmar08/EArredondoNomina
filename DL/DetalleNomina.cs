using System;
using System.Collections.Generic;

namespace DL;

public partial class DetalleNomina
{
    public int IdDetalle { get; set; }

    public int IdNomina { get; set; }

    public string Concepto { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public decimal Monto { get; set; }

    public virtual Nomina IdNominaNavigation { get; set; } = null!;
}
