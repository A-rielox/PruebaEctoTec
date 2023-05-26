using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace API.Controllers;

public class RegistroController : BaseApiController
{
    private readonly IRegistroUsuarioRepository _repo;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public RegistroController(IRegistroUsuarioRepository repo,
                              IMapper mapper,
                              IConfiguration config)
    {
        _repo = repo;
        _mapper = mapper;
        _config = config;
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

        



              
        string fromMail = _config.GetSection("EmailSender").Value;
        string fromPassword = _config.GetSection("EmailPassword").Value;

        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromMail);
        message.Subject = "Test Subject";
        message.To.Add(new MailAddress("arielox.ag@gmail.com"));

        message.Body = "<h3>Estimado " + registro.Nombre + "</h3><br /><p>Hemos recibido sus datos y nos pondremos en contacto con usted en la brevedad posible. Enviaremos un correo con información a su cuenta: " + registro.Email + " </p>" + "<br /><div style=\"width: 100%; font-weight: bold\"><p>Atte.</p><p>Green Leaves</p><p>" + registro.CiudadEstado + " a " + registro.Fecha + "</p></div>";
        
        
        
        
        message.IsBodyHtml = true;

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromMail, fromPassword),
            EnableSsl = true,
        };

        smtpClient.Send(message);







        ////////

        if (await _repo.SaveAllAsync())
        {
            var msgDto = _mapper.Map<RegistroUsuarioDto>(registro);
            return Ok(msgDto);
        }



        return BadRequest("No se pudo crear el registro.");
    }
}
