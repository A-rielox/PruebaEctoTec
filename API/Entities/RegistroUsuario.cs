namespace API.Entities;

public class RegistroUsuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public DateOnly Fecha { get; set; }
    public string CiudadEstado { get; set; }
}
