using Microsoft.AspNetCore.Mvc;
using Blog.DAO;
using Blog.Models;
using System.Collections;
using System.Collections.Generic;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        #region Home
        public IActionResult Index()
        {
            PostDAO dao = new PostDAO();
            IList<Post> listaPublicados = dao.ListaPublicados();
            return View(listaPublicados);
        }
        #endregion

        #region Busca
        public IActionResult Busca(string termo)
        {
            if(termo == null)
                return RedirectToAction("Index");
            else{
                ViewBag.Termo = "Você buscou por: " + termo;
                PostDAO dao = new PostDAO();
                IList<Post> posts = dao.BuscaPeloTermo(termo);
                return View("Index", posts);
            }
        }
        #endregion

        #region BuscaAutocomplete
        [HttpPost]
        public IActionResult BuscaAutocomplete(string termo)
        {
            ViewBag.Termo = "Você buscou por: " + termo;
            PostDAO dao = new PostDAO();
            var model = dao.BuscaPeloTermo(termo);
            return Json(model);
        }
        #endregion
    }
}