using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{

    
    [Authorize(Roles = "Empleado")]
    public class EmpleadoController : Controller
    {
        private readonly BL.Empleado _empleado;
        public EmpleadoController(BL.Empleado empleado)
        {
            _empleado = empleado;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            ML.Result result = _empleado.GetAll();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            return View(empleado);
        }

        [HttpGet]
        public IActionResult Formulario(int? IdEmpleado)
        {
            ML.Empleado Empleado = new ML.Empleado();
            if (IdEmpleado > 0)
            {
              ML.Result result = _empleado.GetById(IdEmpleado.Value);
                if (result.Correct)
                {
                    Empleado = (ML.Empleado)result.Object;
                }            
            }
            return View(Empleado);
        }

        [HttpPost]
        public IActionResult Formulario(ML.Empleado Empleado)
        {
            if (Empleado.IdEmpleado > 0)
            {
                ML.Result result = _empleado.Update(Empleado);
            }
            else
            {
                ML.Result result = _empleado.Add(Empleado);
            }
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Delete(int IdEmpleado)
        {
            ML.Result result = _empleado.Delete(IdEmpleado);
            return RedirectToAction("GetAll");
        }
    }
}
