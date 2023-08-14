using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SiteLanches.Repositories.Interfaces;
using SiteLanches.ViewModels;

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
            //var lanches = _lanchesRepository.Lanches; //comentadop pra usar view model
            //var totalLanches = lanches.Count();
           // ViewBag.TotalLanches = totalLanches;   
            //ViewBag.Total = "Total de Lanches: " ;
            var lanchesListViewModel = new LanchesListViewModel();
            lanchesListViewModel.Lanches = _lanchesRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";
                

            return View(lanchesListViewModel);
            //return View(lanches); //comentado pra usar vview model
        }
    }
}
