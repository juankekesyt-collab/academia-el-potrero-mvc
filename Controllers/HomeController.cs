using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AcademiaFutbolMVC.Models;

namespace AcademiaFutbolMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var categorias = RepositorioDatos.ObtenerCategorias();

        ViewBag.TotalJugadores = RepositorioDatos.ObtenerJugadores().Count;
        ViewBag.TotalCategorias = categorias.Count;
        ViewBag.TotalSedes = Enum.GetValues<Sede>().Length;

        return View(categorias.Take(3).ToList());
    }

    public IActionResult Nosotros()
    {
        ViewBag.TotalJugadores = RepositorioDatos.ObtenerJugadores().Count;
        ViewBag.TotalCategorias = RepositorioDatos.ObtenerCategorias().Count;

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
