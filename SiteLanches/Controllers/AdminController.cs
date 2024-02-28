using Microsoft.AspNetCore.Mvc;

namespace SiteLanches.Controllers
{
    public class AdminController : Controller
    {
        public string Index()
        {
            return $"Testando metodo index de ADMIN controller : {DateTime.Now}";
        }


        public string Demo()
        {
            return $"Testando metodo index de DEMO de ADMIN  controller : {DateTime.Now}";
        }
    }
}
