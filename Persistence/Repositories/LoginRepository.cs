using backendpreguntas.Domain.IRepositories;
using backendpreguntas.Domain.Iservices;
using backendpreguntas.Domain.Models;
using backendpreguntas.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace backendpreguntas.Persistence.Repositories
{
    public class LoginRepository:ILoginRepository
    {
        private readonly AplicationDbContext _context;
        public LoginRepository(AplicationDbContext login)
        {
            _context = login;
        }
        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            var data =await _context.usuarios
                .Where(x=>x.usuario==usuario.usuario && x.password==usuario.password)
                .FirstOrDefaultAsync();
       
            return data ;
        }

    }
}
