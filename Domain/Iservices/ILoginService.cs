using backendpreguntas.Domain.Models;

namespace backendpreguntas.Domain.Iservices
{
    public interface ILoginService
    {
        Task<Usuario> ValidateUser(Usuario usuario);

    }
}
