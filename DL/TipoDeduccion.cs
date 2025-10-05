using System;
using System.Collections.Generic;

namespace DL;

public partial class TipoDeduccion
{
    public int IdTipoDeduccion { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Porcentaje { get; set; }

    public virtual ICollection<Deduccione> Deducciones { get; set; } = new List<Deduccione>();
}
