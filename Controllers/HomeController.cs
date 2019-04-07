using Microsoft.AspNetCore.Mvc;
using Blog.DAO;
using Blog.Models;
using System.Collections;
using System.Collections.Generic;
using Blog.Infra;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostDAO _dao;

        public HomeController(PostDAO dao)
        {
            _dao = dao;
        }

        #region Home
        public IActionResult Index()
        {
            IList<Post> listaPublicados = _dao.ListaPublicados();
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
                IList<Post> posts = _dao.BuscaPeloTermo(termo);
                return View("Index", posts);
            }
        }
        #endregion

        #region BuscaAutocomplete
        [HttpPost]
        public IActionResult BuscaAutocomplete(string termo)
        {
            ViewBag.Termo = "Você buscou por: " + termo;
            var model = _dao.BuscaPeloTermo(termo);
            return Json(model);
        }
        #endregion
    }
}