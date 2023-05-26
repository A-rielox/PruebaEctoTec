using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class RegistroUsuarioRepository : IRegistroUsuarioRepository
{
    private readonly DataContext _context;

    public RegistroUsuarioRepository(DataContext context)
    {
        _context = context;
    }



    ////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    //
    public void AddRegistro(RegistroUsuario registroUsuario)
    {
        _context.RegistroUsuarios.Add(registroUsuario);
    }


    ////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    //
    public async Task<RegistroUsuario> GetRegistroByIdAsync(int id)
    {
        var reg = await _context.RegistroUsuarios.FindAsync(id);

        return reg;
    }


    ////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    //
    public async Task<IEnumerable<RegistroUsuario>> GetRegistrosAsync()
    {
        var regs = await _context.RegistroUsuarios.ToListAsync();

        return regs;
    }


    ////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    //
    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
