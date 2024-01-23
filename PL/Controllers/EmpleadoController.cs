using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers;

public class EmpleadoController : Controller
{
    [HttpGet]
    public IActionResult GetAll()
    {
        ML.Empleado empleado = new();
        ML.Result result = BL.Empleado.GetAll();
        if (result.Correct)
        {
            empleado.Empleados = result.Objects;
            return View(empleado);
        }
        else
        {
            return View(empleado);
        }
    }

    [HttpGet]
    public IActionResult Form(int IdEmpleado)
    {
        ML.Empleado empleado = new()
        {
            Departamento = new ML.Departamento()
        };
        ML.Result resultDepartamento = BL.Departamento.GetAll();
        if (IdEmpleado == 0)
        {
            empleado.Departamento.Departamentos = resultDepartamento.Objects;
            empleado.FechaIngreso = DateTime.Now.Date;
            empleado.FechaNacimiento = DateTime.Now.Date;
            return View(empleado);
        }

        ML.Result result = BL.Empleado.GetById(IdEmpleado);

        if (result.Correct)
        {
            empleado = (ML.Empleado)result.Object;
            empleado.Departamento.Departamentos = resultDepartamento.Objects;
            return View(empleado);
        }
        else
        {
            ViewBag.Message = "Ocurrio un error al consultar la informacion";
            return PartialView("Modal");
        }
    }

    [HttpPost]
    public IActionResult Form(ML.Empleado empleado)
    {
        if (empleado.IdEmpleado == 0)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            if (result.Correct)
            {
                ViewBag.Message = "Se inserto correctamente el registro";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al insertar el registro";
            }
            return PartialView("Modal");
        }
        else
        {
            ML.Result result = BL.Empleado.Update(empleado);
            if (result.Correct)
            {
                ViewBag.Message = "Se actualizo correctamente el registro";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al actualizar el registro";
            }
            return PartialView("Modal");
        }
    }

    [HttpGet]
    public IActionResult Delete(int IdEmpleado, int IdSueldo)
    {
        ML.Result result = BL.Empleado.Delete(IdEmpleado, IdSueldo);
        if (result.Correct)
        {
            ViewBag.Message = "Se inactivo correctamente el registro";
        }
        else
        {
            ViewBag.Message = "Ocurrio un error al inactivar el registro";
        }
        return PartialView("Modal");
    }
}
