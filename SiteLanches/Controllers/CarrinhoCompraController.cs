using Microsoft.AspNetCore.Mvc;
using SiteLanches.Models;
using SiteLanches.Repositories.Interfaces;
using SiteLanches.ViewModels;

namespace SiteLanches.Controllers
{
    public class CarrinhoCompraController : Controller
    {

        private readonly ILanchesRepository _lanchesRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILanchesRepository lanchesRepository, CarrinhoCompra carrinhoCompra)
        {
            _lanchesRepository = lanchesRepository;
            _carrinhoCompra = carrinhoCompra;
        }
         
        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItems();
            _carrinhoCompra.CarrinhoCompraItens = itens;


            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);

        }

        public IActionResult AdiconarItemNoCarrinho(int lancheId)//ID ta vindo nulo 
        {
            
            var lancheSelecionado = _lanchesRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
             if (lancheSelecionado != null) _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            //_carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado); //vendo onde esta o erro de add no carrinho
            return RedirectToAction("Index");

           // return RedirectToAction("Index");

        }

        public IActionResult RemoverItemNoCarrinho(int lancheId)
        {

            var lancheSelecionado = _lanchesRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            if (lancheSelecionado != null) _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            return RedirectToAction("Index");
        }
    }
}
