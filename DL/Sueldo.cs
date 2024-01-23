using System;
using System.Collections.Generic;

namespace DL;

public partial class Sueldo
{
    public int Idsueldo { get; set; }

    public decimal Sueldo1 { get; set; }

    public string? Formapago { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
