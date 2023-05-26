using API.Entities;

namespace API.Interfaces;

public interface IRegistroUsuarioRepository
{
    void AddRegistro(RegistroUsuario registroUsuario);
    Task<RegistroUsuario> GetRegistroByIdAsync(int id);
    Task<IEnumerable<RegistroUsuario>> GetRegistrosAsync();
    Task<bool> SaveAllAsync();
}
