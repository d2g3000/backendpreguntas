using backendpreguntas.Domain.IRepositories;
using backendpreguntas.Domain.Iservices;
using backendpreguntas.Domain.Models;

namespace backendpreguntas.Service
{
    public class UsuarioService:IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _repository= usuarioRepository;
        }

        public async Task SaveUser(Usuario usuario)
        {
            await _repository.SaveUser(usuario);
        }

        public async Task<bool>ValidateExistence(Usuario usuario)
        {
            return await _repository.ValidateExistence(usuario);
        }

        
        public async Task<Usuario>ValidatePassword(int IdUsuario, string Password)
        {
            return await _repository.ValidatePassword(IdUsuario, Password);
        }

         
        public async Task UpdatePassword(Usuario usuario)
        {
             await _repository.UpdatePassword(usuario);
        }

    }
}
