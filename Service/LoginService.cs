using backendpreguntas.Domain.IRepositories;
using backendpreguntas.Domain.Iservices;
using backendpreguntas.Domain.Models;

namespace backendpreguntas.Service
{
    public class LoginService:ILoginService
    {private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository login)
        {
            _loginRepository = login;
        }
       public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            return await _loginRepository.ValidateUser(usuario);
        }
    }
}
