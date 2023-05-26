using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<RegistroUsuario, RegistroUsuarioDto>().ReverseMap();

        CreateMap<RegistroUsuarioCreateDto, RegistroUsuario>().ReverseMap();
    }
}


/*
public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public DateOnly Fecha { get; set; }
    public string CiudadEstado { get; set; }


public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public DateOnly Fecha { get; set; }
    public string CiudadEstado { get; set; }



public string Nombre { get; set; }

    public string Email { get; set; }

    public string Telefono { get; set; }

    public DateOnly Fecha { get; set; }

    public string CiudadEstado { get; set; }

*/