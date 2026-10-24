namespace AcademiaFutbolMVC.Models;

/// <summary>
/// Repositorio en memoria con las categorías y los jugadores de la academia.
/// Para el alcance del curso no se usa base de datos: la información vive
/// mientras la aplicación esté en ejecución.
/// </summary>
public static class RepositorioDatos
{
    private static readonly List<Categoria> _categorias =
    [
        new()
        {
            Id = 1,
            Nombre = "Semillero",
            EdadMinima = 4,
            EdadMaxima = 5,
            Mensualidad = 120000,
            Descripcion = "Primer contacto con el balón: coordinación, juego y diversión en un ambiente seguro.",
            Horario = "Sábados de 8:00 a. m. a 10:00 a. m.",
            Icono = "🌱"
        },
        new()
        {
            Id = 2,
            Nombre = "Sub-8",
            EdadMinima = 6,
            EdadMaxima = 7,
            Mensualidad = 130000,
            Descripcion = "Fundamentos del fútbol: control, pase y conducción con ejercicios lúdicos.",
            Horario = "Martes y jueves de 4:00 a 6:00 p. m.",
            Icono = "⚽"
        },
        new()
        {
            Id = 3,
            Nombre = "Sub-10",
            EdadMinima = 8,
            EdadMaxima = 9,
            Mensualidad = 140000,
            Descripcion = "Técnica individual, visión de juego y primeros partidos de competencia formativa.",
            Horario = "Lunes y miércoles de 4:00 a 6:00 p. m.",
            Icono = "🥅"
        },
        new()
        {
            Id = 4,
            Nombre = "Sub-12",
            EdadMinima = 10,
            EdadMaxima = 11,
            Mensualidad = 150000,
            Descripcion = "Táctica básica, trabajo en equipo y preparación física acorde a la edad.",
            Horario = "Martes y jueves de 4:00 a 6:00 p. m.",
            Icono = "🎯"
        },
        new()
        {
            Id = 5,
            Nombre = "Sub-14",
            EdadMinima = 12,
            EdadMaxima = 13,
            Mensualidad = 150000,
            Descripcion = "Competencia, lectura del juego y fortalecimiento de la confianza en cancha.",
            Horario = "Lunes, miércoles y viernes de 4:00 a 6:00 p. m.",
            Icono = "🛡️"
        },
        new()
        {
            Id = 6,
            Nombre = "Sub-16",
            EdadMinima = 14,
            EdadMaxima = 15,
            Mensualidad = 160000,
            Descripcion = "Alto rendimiento formativo, preparación física y participación en torneos.",
            Horario = "Lunes a jueves de 5:00 a 7:00 p. m.",
            Icono = "🏆"
        },
        new()
        {
            Id = 7,
            Nombre = "Sub-18",
            EdadMinima = 16,
            EdadMaxima = 17,
            Mensualidad = 170000,
            Descripcion = "Preparación para competencias juveniles y proyección deportiva.",
            Horario = "Lunes a viernes de 5:00 a 7:00 p. m.",
            Icono = "🔥"
        }
    ];

    private static readonly List<Jugador> _jugadores = [];
    private static int _siguienteIdJugador = 1;
    private static readonly object _candado = new();

    static RepositorioDatos()
    {
        // Jugadores de ejemplo para que la aplicación no inicie vacía.
        AgregarJugador(new Jugador
        {
            NombreCompleto = "Santiago Ramírez",
            Documento = "1001234567",
            FechaNacimiento = DateTime.Today.AddYears(-9).AddMonths(-2),
            Posicion = Posicion.Mediocampista,
            PieHabil = PieHabil.Derecho,
            Sede = Sede.Norte,
            Acudiente = "Carolina Ramírez",
            Telefono = "300 555 1122",
            Correo = "carolina.ramirez@correo.com",
            TieneHermanoEnAcademia = false,
            AceptaTerminos = true
        });

        AgregarJugador(new Jugador
        {
            NombreCompleto = "Mariana Torres",
            Documento = "1009876543",
            FechaNacimiento = DateTime.Today.AddYears(-12).AddMonths(-4),
            Posicion = Posicion.Delantero,
            PieHabil = PieHabil.Izquierdo,
            Sede = Sede.Sur,
            Acudiente = "Julián Torres",
            Telefono = "310 444 8899",
            Correo = "julian.torres@correo.com",
            TieneHermanoEnAcademia = true,
            AceptaTerminos = true
        });

        AgregarJugador(new Jugador
        {
            NombreCompleto = "Juan José Bedoya",
            Documento = "1012345678",
            FechaNacimiento = DateTime.Today.AddYears(-15).AddMonths(-1),
            Posicion = Posicion.Portero,
            PieHabil = PieHabil.Derecho,
            Sede = Sede.Envigado,
            Acudiente = "Marcela Bedoya",
            Telefono = "320 777 3344",
            Correo = "marcela.bedoya@correo.com",
            TieneHermanoEnAcademia = false,
            AceptaTerminos = true
        });
    }

    public static List<Categoria> ObtenerCategorias()
    {
        return _categorias
            .OrderBy(c => c.EdadMinima)
            .ToList();
    }

    public static Categoria? ObtenerCategoria(int id)
    {
        return _categorias.FirstOrDefault(c => c.Id == id);
    }

    public static Categoria? BuscarCategoriaPorEdad(int edad)
    {
        return _categorias.FirstOrDefault(c => edad >= c.EdadMinima && edad <= c.EdadMaxima);
    }

    public static List<Jugador> ObtenerJugadores(int? categoriaId = null, string? buscar = null)
    {
        IEnumerable<Jugador> consulta = _jugadores;

        if (categoriaId.HasValue)
        {
            consulta = consulta.Where(j => j.CategoriaId == categoriaId.Value);
        }

        if (!string.IsNullOrWhiteSpace(buscar))
        {
            var texto = buscar.Trim();
            consulta = consulta.Where(j =>
                j.NombreCompleto.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                j.Documento.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                j.Acudiente.Contains(texto, StringComparison.OrdinalIgnoreCase));
        }

        return consulta
            .OrderBy(j => j.CategoriaId)
            .ThenBy(j => j.NombreCompleto)
            .ToList();
    }

    public static Jugador? ObtenerJugador(int id)
    {
        return _jugadores.FirstOrDefault(j => j.Id == id);
    }

    public static List<Jugador> ObtenerJugadoresPorCategoria(int categoriaId)
    {
        return _jugadores
            .Where(j => j.CategoriaId == categoriaId)
            .OrderBy(j => j.NombreCompleto)
            .ToList();
    }

    /// <summary>
    /// Calcula la edad exacta en años cumplidos.
    /// </summary>
    public static int CalcularEdad(DateTime fechaNacimiento)
    {
        var hoy = DateTime.Today;
        var edad = hoy.Year - fechaNacimiento.Year;

        if (fechaNacimiento.Date > hoy.AddYears(-edad))
        {
            edad--;
        }

        return edad;
    }

    /// <summary>
    /// Registra al jugador y calcula en C# la edad, la categoría,
    /// la mensualidad y el descuento por hermano.
    /// </summary>
    public static Jugador AgregarJugador(Jugador jugador)
    {
        if (!jugador.FechaNacimiento.HasValue)
        {
            throw new InvalidOperationException("La fecha de nacimiento es obligatoria.");
        }

        var edad = CalcularEdad(jugador.FechaNacimiento.Value);
        var categoria = BuscarCategoriaPorEdad(edad)
            ?? throw new InvalidOperationException("No hay una categoría disponible para esa edad.");

        lock (_candado)
        {
            jugador.Id = _siguienteIdJugador++;
            jugador.Edad = edad;
            jugador.CategoriaId = categoria.Id;
            jugador.Categoria = categoria;
            jugador.MensualidadBase = categoria.Mensualidad;
            jugador.Descuento = jugador.TieneHermanoEnAcademia
                ? decimal.Round(categoria.Mensualidad * 0.10m, 0)
                : 0m;
            jugador.MensualidadFinal = jugador.MensualidadBase - jugador.Descuento;
            jugador.FechaRegistro = DateTime.Now;
            _jugadores.Add(jugador);
        }

        return jugador;
    }
}
