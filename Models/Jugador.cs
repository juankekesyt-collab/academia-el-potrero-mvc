using System.ComponentModel.DataAnnotations;

namespace AcademiaFutbolMVC.Models;

public enum Posicion
{
    Portero,
    Defensa,
    Mediocampista,
    Delantero
}

public enum PieHabil
{
    Derecho,
    Izquierdo,
    Ambidiestro
}

public enum Sede
{
    Norte,
    Sur,
    Envigado
}

/// <summary>
/// Representa la inscripción de un jugador a la academia.
/// La categoría, la edad y la mensualidad se calculan en C# a partir
/// de la fecha de nacimiento.
/// </summary>
public class Jugador
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Escribe el nombre completo del jugador.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "El nombre debe tener entre 5 y 100 caracteres.")]
    [Display(Name = "Nombre completo")]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required(ErrorMessage = "El documento es obligatorio.")]
    [RegularExpression(@"^[0-9]{6,12}$", ErrorMessage = "El documento debe tener entre 6 y 12 números.")]
    [Display(Name = "Documento")]
    public string Documento { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Fecha de nacimiento")]
    public DateTime? FechaNacimiento { get; set; }

    [Required(ErrorMessage = "Selecciona una posición.")]
    [Display(Name = "Posición")]
    public Posicion? Posicion { get; set; }

    [Display(Name = "Pie hábil")]
    public PieHabil PieHabil { get; set; } = PieHabil.Derecho;

    [Required(ErrorMessage = "Selecciona una sede.")]
    [Display(Name = "Sede")]
    public Sede? Sede { get; set; }

    [Required(ErrorMessage = "Escribe el nombre del acudiente.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "El nombre del acudiente debe tener entre 5 y 100 caracteres.")]
    [Display(Name = "Nombre del acudiente")]
    public string Acudiente { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [RegularExpression(@"^[0-9+\s()-]{7,20}$", ErrorMessage = "El teléfono solo puede tener números, espacios, +, - o paréntesis.")]
    [Display(Name = "Teléfono de contacto")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo es obligatorio.")]
    [EmailAddress(ErrorMessage = "Escribe un correo electrónico válido.")]
    [StringLength(120, ErrorMessage = "El correo no puede superar los 120 caracteres.")]
    [Display(Name = "Correo electrónico")]
    public string Correo { get; set; } = string.Empty;

    [Display(Name = "¿Tiene un hermano en la academia?")]
    public bool TieneHermanoEnAcademia { get; set; }

    // La aceptación se valida en el controlador.
    [Display(Name = "Acepto el reglamento y el tratamiento de datos")]
    public bool AceptaTerminos { get; set; }

    [Display(Name = "Fecha de inscripción")]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    [Display(Name = "Edad")]
    public int Edad { get; set; }

    [Display(Name = "Categoría")]
    public int CategoriaId { get; set; }

    /// <summary>Propiedad de navegación hacia la categoría asignada.</summary>
    public Categoria? Categoria { get; set; }

    [Display(Name = "Mensualidad base")]
    public decimal MensualidadBase { get; set; }

    [Display(Name = "Descuento")]
    public decimal Descuento { get; set; }

    [Display(Name = "Mensualidad final")]
    public decimal MensualidadFinal { get; set; }

    [Display(Name = "Estado")]
    public string Estado { get; set; } = "Inscrito";
}
