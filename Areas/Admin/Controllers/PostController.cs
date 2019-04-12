using System;
using System.Collections;
using System.Collections.Generic;
using Blog.DAO;
using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AutorizacaoFilter]
    public class PostController : Controller
    {
        private readonly PostDAO _dao;

        public PostController(PostDAO dao)
        {
            _dao = dao;       
        }


        #region Index
        public IActionResult Index()
        {
            IList<Post> listPosts = new List<Post>();

            listPosts = _dao.Lista();

            return View(listPosts);
        }
        #endregion

        #region Novo
        public IActionResult Novo()
        {
            var model = new Post();
            return View(model);
        }
        #endregion

        #region Categoria
        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            var listaCategoria = _dao.FiltraPorCategoria(categoria);

            return View("Index", listaCategoria);
        }
        #endregion

        #region Adiciona
        [HttpPost]
        public IActionResult Adiciona(Post post)
        {
            if(ModelState.IsValid)
            {
                _dao.Adiciona(post);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Novo", post);
            }
            
        }
        #endregion
    
        #region Remove
        public IActionResult Remove(int id)
        {
            _dao.Remove(id);

            return RedirectToAction("Index");
        }
        #endregion
    
        #region Visualiza
        public IActionResult Visualiza(int id)
        {
            Post post = _dao.ListaPorId(id);

            return View("Visualiza", post);
        }
        #endregion

        #region Atualiza
        public IActionResult Atualiza(Post post)
        {
            if(ModelState.IsValid)
            {
                _dao.Atualiza(post);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Visualiza", post);
            }
        }
        #endregion

        #region Publica
        public IActionResult Publica(int id)
        {
            _dao.Publica(id);

            return RedirectToAction("Index");
        }
        #endregion
   
        #region CategoriaAutocomplete
        [HttpPost]
        public IActionResult CategoriaAutocomplete(string termo)
        {
            var model = _dao.FiltraPorCategoriaTermo(termo);
            return Json(model);
        }
        #endregion
    }   
}
