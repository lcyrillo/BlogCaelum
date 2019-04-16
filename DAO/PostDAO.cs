using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Infra;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAO
{
    public class PostDAO
    {
        private readonly BlogContext _context;

        public PostDAO(BlogContext context) => this._context = context;

        #region Lista
        public IList<Post> Lista()
        {
            var lista = _context.Posts.ToList();
            return lista;
        }
        #endregion

        #region ListaPorId
        public Post ListaPorId(int id)
        {
            Post post = _context.Posts.Find(id);

            return post;
        }
        #endregion

        #region Adiciona
        public void Adiciona(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
        #endregion

        #region Adiciona PostUsuario
        public void Adiciona(Post post, Usuario usuario)
        {
            _context.Usuarios.Attach(usuario);
            post.Autor = usuario;
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
        #endregion

        #region FiltraPorCategoria
        public IList<Post> FiltraPorCategoria(string categoria)
        {
            var lista = from post in _context.Posts
                        where post.Categoria.Contains(categoria)
                        select post;

            return lista.ToList();
        }
        #endregion

        #region Remove
        public void Remove(int id)
        {
            Post post = _context.Posts.Find(id);

            _context.Posts.Remove(post);

            _context.SaveChanges();
        }
        #endregion

        #region Atualiza
        public void Atualiza(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();
        }
        #endregion
        
        #region Publica
        public void Publica(int id)
        {
            Post post = _context.Posts.Find(id);

            post.Publicado = true;
            post.DataPublicacao = DateTime.Now;

            _context.SaveChanges();
        }
        #endregion
    
        #region FiltraPorCategoriaTermo
        public IList<string> FiltraPorCategoriaTermo(string termo)
        {
            return _context.Posts.Where(p => p.Categoria.Contains(termo))
                            .Select(p => p.Categoria)
                            .Distinct()
                            .ToList();
        }
        #endregion

        #region ListaPublicados
        public IList<Post> ListaPublicados()
        {
            return _context.Posts.Where(p => p.Publicado)
                                .OrderByDescending(p => p.DataPublicacao).ToList();
        }
        #endregion

        #region BuscaPeloTermo
        public IList<Post> BuscaPeloTermo(string termo)
        {
            return _context.Posts.Where(p => p.Resumo.Contains(termo)
                                        || p.Titulo.Contains(termo)
                                        && p.Publicado).ToList();
        }
        #endregion
    }
}


#region examples
// public IList<Post> ListaADONET()
        // {
        //     IList<Post> listaPosts = new List<Post>();

        //     using (SqlConnection connection = ConnectionFactory.CriaConexao())
        //     {
        //         SqlCommand command = connection.CreateCommand();
        //         command.CommandText = "select * from Posts";
        //         SqlDataReader reader = command.ExecuteReader();
        //         while (reader.Read())
        //         {
        //             Post post = new Post()
        //             {
        //                 Id = Convert.ToInt32(reader["Id"]),
        //                 Titulo = Convert.ToString(reader["Titulo"]),
        //                 Resumo = Convert.ToString(reader["Resumo"]),
        //                 Categoria = Convert.ToString(reader["Categoria"])
        //             };
        //             listaPosts.Add(post);
        //         }
        //     }

        //     return listaPosts;
        // }
#endregion