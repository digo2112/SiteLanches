using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SiteLanches.Models;
using SiteLanches.Repositories;
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

        public IActionResult List(string categoria)
        {
            ViewData["Titulo"] = "Todos os lanches";
            ViewData["Data"] = DateTime.Now;

            /*//var lanches = _lanchesRepository.Lanches; //comentadop pra usar view model
            //var totalLanches = lanches.Count();
           // ViewBag.TotalLanches = totalLanches;   
            //ViewBag.Total = "Total de Lanches: " ;
            var lanchesListViewModel = new LanchesListViewModel();
            lanchesListViewModel.Lanches = _lanchesRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual"; TRECHO COMENTADO PARA FILTRAR POR CATEGORIA */



            IEnumerable<Lanche> lanches = Enumerable.Empty<Lanche>(); //copilot, tava dando erro pq variavel nao foi inicializada
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lanchesRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                lanches = _lanchesRepository.Lanches
                    .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(l => l.Nome);

                categoriaAtual = categoria;



            }

            /*comedntado trecho abaixo pq fixa ewssas categorias, caso outra seja criada nao vai encontrar*/
            //if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
            //{
            //    lanches = _lanchesRepository.Lanches
            //        .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
            //        .OrderBy(l => l.Nome);

            //    categoriaAtual = categoria;
            //}

            //if (string.Equals("Natural", categoria, StringComparison.OrdinalIgnoreCase))
            //{
            //    lanches = _lanchesRepository.Lanches
            //        .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
            //        .OrderBy(l => l.Nome);

            //    categoriaAtual = categoria;
            //}

            var lanchesListViewModel = new LanchesListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesListViewModel);
            //return View(lanches); //comentado pra usar vview model
        }

        public IActionResult Details(int LancheId)
        {
            var lanche = _lanchesRepository.Lanches.FirstOrDefault(l => l.LancheId == LancheId);
            return View(lanche);
        }



        public ViewResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches = Enumerable.Empty<Lanche>(); 
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lanchesRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";

            }
            else
            {

                lanches = _lanchesRepository.Lanches
                           .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (lanches.Any())
                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }
            return View("~/Views/Lanche/List.cshtml", new LanchesListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
        }


    }
}
