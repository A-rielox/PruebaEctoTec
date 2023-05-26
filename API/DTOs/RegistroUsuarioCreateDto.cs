using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegistroUsuarioCreateDto
{
    [Required(ErrorMessage = "El Nombre es requerido")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El Email es requerido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "El Telefono es requerido")]
    public string Telefono { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateOnly Fecha { get; set; }

    [Required(ErrorMessage = "La Ciudad y Estado es requerida")]
    public string CiudadEstado { get; set; }
}
