using System;
using System.Collections.Generic;

namespace DL;

public partial class Departamento
{
    public int Iddepartamento { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
