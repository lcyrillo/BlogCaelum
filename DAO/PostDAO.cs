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

        #region Lista
        public IList<Post> Lista()
        {
            using(BlogContext context = new BlogContext())
            {
                var lista = context.Posts.ToList();
                return lista;
            }
        }
        #endregion

        #region ListaPorId
        public Post ListaPorId(int id)
        {
            using(BlogContext context = new BlogContext())
            {
                Post post = context.Posts.Find(id);

                return post;
            }
        }
        #endregion

        #region Adiciona
        public void Adiciona(Post post)
        {
            using(BlogContext context = new BlogContext())
            {
                context.Posts.Add(post);
                context.SaveChanges();
            }
        }
        #endregion

        #region FiltraPorCategoria
        public IList<Post> FiltraPorCategoria(string categoria)
        {
            using(BlogContext context = new BlogContext())
            {
                var lista = from post in context.Posts
                            where post.Categoria.Contains(categoria)
                            select post;

                return lista.ToList();
            }
        }
        #endregion

        #region Remove
        public void Remove(int id)
        {
            using(BlogContext context = new BlogContext())
            {
                Post post = context.Posts.Find(id);

                context.Posts.Remove(post);

                context.SaveChanges();
            }
        }
        #endregion

        #region Atualiza
        public void Atualiza(Post post)
        {
            using(BlogContext context = new BlogContext())
            {
                context.Entry(post).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        #endregion
        
        #region Publica
        public void Publica(int id)
        {
            using(BlogContext context = new BlogContext())
            {
                Post post = context.Posts.Find(id);

                post.Publicado = true;
                post.DataPublicacao = DateTime.Now;

                context.SaveChanges();
            }
        }
        #endregion
    
        #region FiltraPorCategoriaTermo
        public IList<string> FiltraPorCategoriaTermo(string termo)
        {
            using(BlogContext context = new BlogContext())
            {
                return context.Posts.Where(p => p.Categoria.Contains(termo))
                             .Select(p => p.Categoria)
                             .Distinct()
                             .ToList();
            }
        }
        #endregion

        #region ListaPublicados
        public IList<Post> ListaPublicados()
        {
            using(BlogContext context = new BlogContext())
            {
                return context.Posts.Where(p => p.Publicado)
                                    .OrderByDescending(p => p.DataPublicacao).ToList();
            }
        }
        #endregion

        #region BuscaPeloTermo
        public IList<Post> BuscaPeloTermo(string termo)
        {
            using(BlogContext context = new BlogContext())
            {
                return context.Posts.Where(p => p.Resumo.Contains(termo)
                                           || p.Titulo.Contains(termo)
                                           && p.Publicado).ToList();
            }
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