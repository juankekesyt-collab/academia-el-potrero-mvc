using Microsoft.AspNetCore.Mvc;
using AcademiaFutbolMVC.Models;

namespace AcademiaFutbolMVC.Controllers;

public class CategoriasController : Controller
{
    public IActionResult Index()
    {
        return View(RepositorioDatos.ObtenerCategorias());
    }

    public IActionResult Details(int id)
    {
        var categoria = RepositorioDatos.ObtenerCategoria(id);

        if (categoria is null)
        {
            return NotFound();
        }

        ViewBag.Jugadores = RepositorioDatos.ObtenerJugadoresPorCategoria(id);

        return View(categoria);
    }
}
