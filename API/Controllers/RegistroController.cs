using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RegistroController : BaseApiController
{
    private readonly IRegistroUsuarioRepository _repo;
    private readonly IMapper _mapper;

    public RegistroController(IRegistroUsuarioRepository repo,
                              IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }



    /////////////////////////////////////////
    /////////////////////////////////////////
    ///// GET:  api/Registro
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegistroUsuario>>> GetUsers()
    {
        var regs = await _repo.GetRegistrosAsync();

        return Ok(regs);
    }

    /////////////////////////////////////////
    /////////////////////////////////////////
    //////// GET:  api/Registro/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<RegistroUsuario>> GetUser(int id)
    {
        var reg = await _repo.GetRegistroByIdAsync(id);

        return Ok(reg);
    }

    ////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    // POST:  api/Registro
    [HttpPost]
    public async Task<ActionResult<RegistroUsuarioDto>> CreateRegistro(RegistroUsuarioCreateDto createDTO)
    {
        var registro = _mapper.Map<RegistroUsuario>(createDTO);

        _repo.AddRegistro(registro);

        if (await _repo.SaveAllAsync())
        {
            var msgDto = _mapper.Map<RegistroUsuarioDto>(registro);

            return Ok(msgDto);
        }

        return BadRequest("No se pudo crear el registro.");
    }
}
