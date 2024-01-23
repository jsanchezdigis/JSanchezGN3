using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers;

public class DepartamentoController : Controller
{
    [HttpGet]
    public IActionResult GetAll()
    {
        ML.Departamento departamento = new();
        ML.Result result = BL.Departamento.GetAll();
        if (result.Correct)
        {
            departamento.Departamentos = result.Objects;
            return View(departamento);
        }
        else
        {
            return View(departamento);
        }
    }

    [HttpGet]
    public IActionResult Form(int IdDepartamento)
    {
        ML.Departamento departamento = new();
        ML.Result result = BL.Departamento.GetById(IdDepartamento);
        if (result.Correct)
        {
            departamento = (ML.Departamento)result.Object;
            return View(departamento);
        }
        else
        {
            return View(departamento);
        }
    }

    [HttpPost]
    public IActionResult Form(ML.Departamento departamento)
    {
        if (departamento.IdDepartamento == 0)
        {
            ML.Result result = BL.Departamento.Add(departamento);
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
            ML.Result result = BL.Departamento.Update(departamento);
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
    public IActionResult Delete(int IdDepartamento)
    {
        ML.Result result = BL.Departamento.Delete(IdDepartamento);
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
