using Microsoft.EntityFrameworkCore;
using ML;

namespace BL;

public class Departamento
{
    public static Result Add(ML.Departamento departamento)
    {
        Result result = new();
        try
        {
            using DL.JsanchezGn3Context context = new();
            var query = context.Database.ExecuteSql($"DepartamentoAdd {departamento.Descripcion}");
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

    public static Result Update(ML.Departamento departamento)
    {
        Result result = new();
        try
        {
            using DL.JsanchezGn3Context context = new();
            var query = context.Database.ExecuteSql($"DepartamentoUpdate {departamento.IdDepartamento},{departamento.Descripcion}");
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

    public static Result Delete(int IdDepartamento)
    {
        Result result = new();
        try
        {
            using DL.JsanchezGn3Context context = new();
            var query = context.Database.ExecuteSql($"DepartamentoDelete {IdDepartamento}");
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
            var query = context.Departamentos.FromSqlRaw("DepartamentoGetAll").ToList();
            if (query != null)
            {
                result.Objects = [];
                foreach (var item in query)
                {
                    ML.Departamento departamento = new()
                    {
                        IdDepartamento = item.Iddepartamento,
                        Descripcion = item.Descripcion
                    };
                    result.Objects.Add(departamento);
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

    public static Result GetById(int IdDepartamento)
    {
        Result result = new();
        try
        {
            using DL.JsanchezGn3Context context = new();
            var query = context.Departamentos.FromSql($"DepartamentoGetById {IdDepartamento}").AsEnumerable().FirstOrDefault();
            if (query != null)
            {
                var item = query;

                result.Object = new();
                ML.Departamento departamento = new()
                {
                    IdDepartamento = item.Iddepartamento,
                    Descripcion = item.Descripcion
                };
                result.Object = departamento;
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
