namespace ML;

public class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public Departamento Departamento { get; set; }

    public Sueldo Sueldo { get; set; }

    public List<object> Empleados { get; set; }
}
