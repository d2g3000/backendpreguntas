using backendpreguntas.Domain.IRepositories;
using backendpreguntas.Domain.Models;
using backendpreguntas.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace backendpreguntas.Persistence.Repositories
{
    public class UsuarioRepository:IUsuarioRepository
    {
        private readonly AplicationDbContext _context;
        public UsuarioRepository(AplicationDbContext context)
        {
            _context=context;
        }
        public async Task SaveUser(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ValidateExistence(Usuario user)
        {
            var validate =  await _context.usuarios.AnyAsync(x=>x.usuario== user.usuario);

            return validate;
        }

        public async Task<Usuario> ValidatePassword(int IdUsuario, string Password)
        {
            var usuario = await _context.usuarios.Where(x => x.Id == IdUsuario && x.password == Password).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task UpdatePassword(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
           
        }
    }
}
