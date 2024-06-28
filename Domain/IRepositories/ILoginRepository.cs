using backendpreguntas.Domain.Iservices;
using backendpreguntas.Domain.Models;

namespace backendpreguntas.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
