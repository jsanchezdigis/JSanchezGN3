using System;
using System.Collections.Generic;

namespace DL;

public partial class Empleado
{
    public int Idempleado { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly Fechaingreso { get; set; }

    public DateOnly Fechanacimiento { get; set; }

    public int Iddepartamento { get; set; }

    public int Idsueldo { get; set; }

    public string? Descripcion { get; set; }

    public decimal Sueldo { get; set; }

    public string? FormaPago { get; set; }

    public virtual Departamento IddepartamentoNavigation { get; set; } = null!;

    public virtual Sueldo IdsueldoNavigation { get; set; } = null!;
}
