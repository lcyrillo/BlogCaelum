using System;
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
        public IActionResult Adiciona(Post post)
        {
            PostDAO dao = new PostDAO();

            dao.Adiciona(post);

            return RedirectToAction("Index");
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
        public IActionResult Visualiza(int id)
        {
            PostDAO dao = new PostDAO();

            Post post = dao.ListaPorId(id);

            return View("Visualiza", post);
        }
        #endregion

        #region Atualiza
        public IActionResult Atualiza(Post post)
        {
            PostDAO dao = new PostDAO();

            dao.Atualiza(post);

            return RedirectToAction("Index");
        }
        #endregion

        #region Publica
        public IActionResult Publica(int id)
        {
            PostDAO dao = new PostDAO();

            dao.Publica(id);

            return RedirectToAction("Index");
        }
        #endregion
    }   
}
