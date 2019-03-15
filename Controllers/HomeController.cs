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
    }
}