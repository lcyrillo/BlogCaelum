
using System.Linq;
using Blog.Infra;
using Blog.Models;
using Blog.ViewModels;

namespace Blog.DAO
{
    public class UsuarioDAO
    {
        public readonly BlogContext _context;

        public UsuarioDAO(BlogContext context)
        {
            _context = context;
        }

        public Usuario Busca(string login, string senha)
        {
            return _context.Usuarios.Where(u => u.Nome.Equals(login) && u.Senha.Equals(senha)).FirstOrDefault<Usuario>();
        }
    }
}