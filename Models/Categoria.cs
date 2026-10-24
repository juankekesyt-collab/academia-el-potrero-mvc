using System.ComponentModel.DataAnnotations;

namespace AcademiaFutbolMVC.Models;

/// <summary>
/// Categoría deportiva de la academia. Agrupa a los jugadores por edad
/// y define la mensualidad y el horario de entrenamiento.
/// </summary>
public class Categoria
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
    [StringLength(30, ErrorMessage = "El nombre no puede superar los 30 caracteres.")]
    [Display(Name = "Categoría")]
    public string Nombre { get; set; } = string.Empty;

    [Range(4, 17, ErrorMessage = "La edad mínima debe estar entre 4 y 17 años.")]
    [Display(Name = "Edad mínima")]
    public int EdadMinima { get; set; }

    [Range(4, 17, ErrorMessage = "La edad máxima debe estar entre 4 y 17 años.")]
    [Display(Name = "Edad máxima")]
    public int EdadMaxima { get; set; }

    [Range(1000, 1000000, ErrorMessage = "La mensualidad debe ser mayor a $1.000.")]
    [Display(Name = "Mensualidad")]
    public decimal Mensualidad { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [StringLength(240, ErrorMessage = "La descripción no puede superar los 240 caracteres.")]
    [Display(Name = "Descripción")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El horario es obligatorio.")]
    [StringLength(100)]
    [Display(Name = "Horario")]
    public string Horario { get; set; } = string.Empty;

    [StringLength(10)]
    public string Icono { get; set; } = "⚽";

    /// <summary>Texto listo para mostrar en las tarjetas: "8 a 9 años".</summary>
    public string RangoEdad => $"{EdadMinima} a {EdadMaxima} años";
}
