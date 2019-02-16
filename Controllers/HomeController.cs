using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        #region Home
        public IActionResult Index() => View();
        #endregion
    }
}