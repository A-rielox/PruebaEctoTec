namespace API.DTOs;

public class RegistroUsuarioDto
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public DateOnly Fecha { get; set; }
    public string CiudadEstado { get; set; }
}
