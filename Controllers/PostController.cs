using System.Collections;
using System.Collections.Generic;
using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {

        #region Index
        public IActionResult Index()
        {
            IList<Post> listPosts = new List<Post>();

            PostDAO dao = new PostDAO();

            listPosts = dao.Lista();

            return View(listPosts);
        }
        #endregion

        #region Novo
        public IActionResult Novo() => View();
        #endregion

        #region Categoria
        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            PostDAO dao = new PostDAO();

            var listaCategoria = dao.FiltraPorCategoria(categoria);

            return View("Index", listaCategoria);
        }
        #endregion

        #region Adiciona
        [HttpPost]
        public void Adiciona(Post post)
        {
            PostDAO dao = new PostDAO();

            dao.Adiciona(post);

            RedirectToAction("Index");
        }
        #endregion
    
        #region Remove
        public IActionResult Remove(int id)
        {
            PostDAO dao = new PostDAO();

            dao.Remove(id);

            return RedirectToAction("Index");
        }
        #endregion
    
        #region Visualiza
        public Post Visualiza(int id)
        {
            PostDAO dao = new PostDAO();

            Post post = dao.listaPorId(id);

            return View("Visualiza", post);
        }
        #endregion

        #region Edita
        public IActionResult Edita(Post post)
        {
            
        }
        #endregion
    }   
}
