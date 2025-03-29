using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CasaDeCambio.Models;

namespace CasaDeCambio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Monedas = new List<string> { "BRL", "PEN", "USD" };
        return View();
    }

    [HttpPost]
    public IActionResult Convertir(decimal cantidad, string origen, string destino)
    {
        var tasasCambio = new Dictionary<string, decimal>
        {
            { "BRL-PEN", 0.63m },
            { "PEN-BRL", 1.58m },
            { "BRL-USD", 0.17m },
            { "USD-BRL", 5.76m },
            { "PEN-USD", 0.27m },
            { "USD-PEN", 3.65m }
        };

        string clave = $"{origen}-{destino}";
        decimal resultado = tasasCambio.ContainsKey(clave) ? cantidad * tasasCambio[clave] : 0;
        
        ViewBag.Resultado = resultado;
        ViewBag.Cantidad = cantidad;
        ViewBag.Origen = origen;
        ViewBag.Destino = destino;
        ViewBag.Monedas = new List<string> { "BRL", "PEN", "USD" };

        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
