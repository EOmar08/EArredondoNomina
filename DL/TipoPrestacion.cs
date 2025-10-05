using System;
using System.Collections.Generic;

namespace DL;

public partial class TipoPrestacion
{
    public int IdTipoPrestacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Prestacione> Prestaciones { get; set; } = new List<Prestacione>();
}
