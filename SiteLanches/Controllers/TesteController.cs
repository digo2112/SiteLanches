using Microsoft.AspNetCore.Mvc;

namespace SiteLanches.Controllers
{
    public class TesteController : Controller
    {
        public string Index()
        {
            return $"Testando metodo index de teste controller : {DateTime.Now}";
        }
    }
}
