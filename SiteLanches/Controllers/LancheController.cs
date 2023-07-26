using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SiteLanches.Repositories.Interfaces;

namespace SiteLanches.Controllers
{
    public class LancheController : Controller
    {

        private readonly ILanchesRepository _lanchesRepository;

        public LancheController(ILanchesRepository lanchesRepository)
        {
            _lanchesRepository = lanchesRepository;
        }

        public IActionResult List()
        {
            ViewData["Titulo"] = "Todos os lanches";
            ViewData["Data"] = DateTime.Now;
            var lanches = _lanchesRepository.Lanches;
            var totalLanches = lanches.Count();
            ViewBag.TotalLanches = totalLanches;   
            ViewBag.Total = "Total de Lanches: " ;
         
            return View(lanches);
        }
    }
}
