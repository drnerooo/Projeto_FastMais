using Microsoft.AspNetCore.Mvc;

namespace Fast_Teste.Areas.admin.Controllers
{
    public class PrincipalController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
