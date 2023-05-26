using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegistroUsuarioCreateDto
{
    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Telefono { get; set; }

    [Required]
    public DateOnly Fecha { get; set; }

    [Required]
    public string CiudadEstado { get; set; }
}
