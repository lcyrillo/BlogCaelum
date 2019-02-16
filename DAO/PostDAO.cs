using System.Collections.Generic;
using System.Linq;
using Blog.Infra;
using Blog.Models;

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