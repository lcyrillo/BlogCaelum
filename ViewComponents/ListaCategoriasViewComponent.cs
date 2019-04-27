using Blog.DAO;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.ViewComponents
{
    public class ListaCategoriasViewComponent : ViewComponent
    {
        private readonly PostDAO _dao;

        public ListaCategoriasViewComponent(PostDAO dao)
        {
            _dao = dao;
        }

        public IViewComponentResult Invoke()
        {
            var posts = _dao.ListaPublicados();
            CategoriaComQuantidadeViewModel categoriaQuantidade = new CategoriaComQuantidadeViewModel(posts);
            return View(categoriaQuantidade);
        }
    }
}