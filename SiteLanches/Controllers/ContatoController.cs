using Microsoft.AspNetCore.Mvc;

namespace SiteLanches.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            //nao entendi pq aqui no contato...
            if(User.Identity.IsAuthenticated) return View();
            return RedirectToAction("Login", "Account");
        }
    }
}
