namespace API.DTOs;

public class EmailDto
{
    public EmailDto(string para, string subject, string body, string nombre, string cuenta, string ciudadEstado, string fecha)
    {
        Para = para;
        Subject = subject;
        Body = body;
        Nombre = nombre;
        Cuenta = cuenta;
        CiudadEstado = ciudadEstado;
        Fecha = fecha;
    }

    public string Para { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;


    public string Nombre { get; set; }
    public string Cuenta { get; set; }
    public string CiudadEstado { get; set; }
    public string Fecha { get; set; }
}
