using Microsoft.AspNetCore.Mvc;

public class BoletaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GenerarBoleta(string nombre, string dni)
    {
        ViewBag.Nombre = nombre;
        ViewBag.DNI = dni;
        return View("Confirmacion");
    }
}
