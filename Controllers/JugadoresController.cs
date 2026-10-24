using Microsoft.AspNetCore.Mvc;
using AcademiaFutbolMVC.Models;

namespace AcademiaFutbolMVC.Controllers;

public class JugadoresController : Controller
{
    /// <summary>
    /// Lista de jugadores inscritos. Los filtros llegan por la URL (GET):
    /// /Jugadores?categoriaId=3&amp;buscar=santiago
    /// </summary>
    public IActionResult Index(int? categoriaId, string? buscar)
    {
        var jugadores = RepositorioDatos.ObtenerJugadores(categoriaId, buscar);

        ViewBag.Categorias = RepositorioDatos.ObtenerCategorias();
        ViewBag.CategoriaActual = categoriaId;
        ViewBag.Buscar = buscar;
        ViewBag.TotalJugadores = jugadores.Count;
        ViewBag.TotalGeneral = RepositorioDatos.ObtenerJugadores().Count;
        ViewBag.RecaudoMensual = jugadores.Sum(j => j.MensualidadFinal);

        return View(jugadores);
    }

    /// <summary>Muestra el formulario de inscripción (GET).</summary>
    public IActionResult Create()
    {
        CargarCategorias();
        return View(new Jugador());
    }

    /// <summary>
    /// Recibe el formulario (POST), valida los datos, calcula la edad,
    /// la categoría y la mensualidad en C#, y redirige a la confirmación.
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Jugador jugador)
    {
        if (!jugador.AceptaTerminos)
        {
            ModelState.AddModelError(nameof(Jugador.AceptaTerminos),
                "Debes aceptar el reglamento y el tratamiento de datos.");
        }

        if (!jugador.FechaNacimiento.HasValue)
        {
            ModelState.AddModelError(nameof(Jugador.FechaNacimiento),
                "La fecha de nacimiento es obligatoria.");
        }
        else if (jugador.FechaNacimiento.Value.Date > DateTime.Today)
        {
            ModelState.AddModelError(nameof(Jugador.FechaNacimiento),
                "La fecha de nacimiento no puede ser futura.");
        }
        else
        {
            var edad = RepositorioDatos.CalcularEdad(jugador.FechaNacimiento.Value);

            if (edad < 4 || edad > 17)
            {
                ModelState.AddModelError(nameof(Jugador.FechaNacimiento),
                    "La academia recibe jugadores entre 4 y 17 años.");
            }
        }

        if (!ModelState.IsValid)
        {
            CargarCategorias();
            return View(jugador);
        }

        try
        {
            RepositorioDatos.AgregarJugador(jugador);
        }
        catch (InvalidOperationException)
        {
            ModelState.AddModelError(nameof(Jugador.FechaNacimiento),
                "No hay una categoría disponible para esa edad.");
            CargarCategorias();
            return View(jugador);
        }

        TempData["Mensaje"] = "La inscripción quedó registrada. ¡Bienvenido a El Potrero!";

        // Post/Redirect/Get: al refrescar no se duplica la inscripción.
        return RedirectToAction(nameof(Confirmacion), new { id = jugador.Id });
    }

    public IActionResult Confirmacion(int id)
    {
        var jugador = RepositorioDatos.ObtenerJugador(id);

        if (jugador is null)
        {
            return NotFound();
        }

        return View(jugador);
    }

    private void CargarCategorias()
    {
        ViewBag.Categorias = RepositorioDatos.ObtenerCategorias();
    }
}
