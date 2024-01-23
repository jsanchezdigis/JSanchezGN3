using Microsoft.EntityFrameworkCore;
using ML;

namespace BL;

public class Empleado
{
    public static Result Add(ML.Empleado empleado)
    {
        Result result = new();
        try
        {
            using DL.JsanchezGn3Context context = new();
            var query = context.Database.ExecuteSql($"EmpleadoAdd {empleado.Nombre},{empleado.FechaIngreso.ToString("dd/MM/yyyy")},{empleado.FechaNacimiento.ToString("dd/MM/yyyy")},{empleado.Departamento.IdDepartamento},{empleado.Sueldo.Sueldo1},{empleado.Sueldo.FormaPago}");
            if (query >= 1)
            {
                result.Correct = true;
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "Error al insertar el registro";
            }
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
            result.Ex = ex;
        }
        return result;
    }

    public static Result Update(ML.Empleado empleado)
    {
        Result result = new();
        try
        {
            using DL.JsanchezGn3Context context = new();
            var query = context.Database.ExecuteSql($"EmpleadoUpdate {empleado.IdEmpleado},{empleado.Nombre},{empleado.FechaIngreso.ToString("dd/MM/yyyy")},{empleado.FechaNacimiento.ToString("dd/MM/yyyy")},{empleado.Departamento.IdDepartamento},{empleado.Sueldo.IdSueldo},{empleado.Sueldo.Sueldo1},{empleado.Sueldo.FormaPago}");
            if (query >= 1)
            {
                result.Correct = true;
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "Error al actualizar el registro";
            }
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
            result.Ex = ex;
        }
        return result;
    }

    public static Result Delete(int IdEmpleado,int IdSueldo)
    {
        Result result = new();
        try
        {
            using DL.JsanchezGn3Context context = new();
            var query = context.Database.ExecuteSql($"EmpleadoDelete {IdEmpleado},{IdSueldo}");
            if (query >= 1)
            {
                result.Correct = true;
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "Error al inactivar el registro";
            }
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
            result.Ex = ex;
        }
        return result;
    }

    public static Result GetAll()
    {
        Result result = new();
        try
        {
            using DL.JsanchezGn3Context context = new();
            var query = context.Empleados.FromSqlRaw("EmpleadoGetAll").ToList();
            if (query != null)
            {
                result.Objects = [];
                foreach (var item in query)
                {
                    ML.Empleado empleado = new()
                    {
                        IdEmpleado = item.Idempleado,
                        Nombre = item.Nombre,
                        FechaIngreso = new DateTime(item.Fechaingreso.Year, item.Fechaingreso.Month, item.Fechaingreso.Day),
                        FechaNacimiento = new DateTime(item.Fechanacimiento.Year, item.Fechanacimiento.Month, item.Fechanacimiento.Day),
                        Departamento = new() 
                        {
                            IdDepartamento = item.Iddepartamento,
                            Descripcion = item.Descripcion,
                        },
                        Sueldo = new()
                        {
                            IdSueldo = item.Idsueldo,
                            Sueldo1 = item.Sueldo,
                            FormaPago = item.FormaPago
                        }
                    };
                    result.Objects.Add(empleado);
                }
            }
            result.Correct = true;
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
            result.Ex = ex;
        }
        return result;
    }

    public static Result GetById(int IdEmpelado)
    {
        Result result = new();
        try
        {
            using DL.JsanchezGn3Context context = new();
            var query = context.Empleados.FromSql($"EmpleadoGetById {IdEmpelado}").AsEnumerable().FirstOrDefault();
            if (query != null)
            {
                var item = query;

                result.Object = new();
                ML.Empleado empleado = new()
                {
                    IdEmpleado = item.Idempleado,
                    Nombre = item.Nombre,
                    FechaIngreso = new DateTime(item.Fechaingreso.Year, item.Fechaingreso.Month, item.Fechaingreso.Day),
                    FechaNacimiento = new DateTime(item.Fechanacimiento.Year, item.Fechanacimiento.Month, item.Fechanacimiento.Day),
                    Departamento = new()
                    {
                        IdDepartamento = item.Iddepartamento,
                        Descripcion = item.Descripcion,
                    },
                    Sueldo = new()
                    {
                        IdSueldo = item.Idsueldo,
                        Sueldo1 = item.Sueldo,
                        FormaPago = item.FormaPago
                    }
                };
                result.Object = empleado;
                result.Correct = true;
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error, no se encuentra el registro";
            }
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
            result.Ex = ex;
        }
        return result;
    }
}
