using Blog.DAO;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDAO _dao;
        public UsuarioController(UsuarioDAO dao)
        {
            _dao = dao;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Autentica(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                Usuario usuario = _dao.Busca(model.LoginName, model.Password);

                if(usuario != null)
                {
                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));
                    return RedirectToAction("Index", "Post", new { area = "Admin"} );
                }
                else
                {
                    ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                }
            }
            return View("Login", model);
        }
    }
}