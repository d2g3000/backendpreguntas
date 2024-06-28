using backendpreguntas.Domain.Models;

namespace backendpreguntas.Domain.Iservices
{
    public interface IUsuarioService
    {
        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task <Usuario> ValidatePassword(int IdUsuario,string Password);
        Task UpdatePassword(Usuario usuario);
    }
}
