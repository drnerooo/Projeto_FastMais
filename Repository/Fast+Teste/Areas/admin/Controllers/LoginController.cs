using Business.Models;
using Fast_Teste.Util;
using Microsoft.AspNetCore.Mvc;
using Repository.EF;
using Services;

namespace Fast_Teste.Areas.admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        private Context _context;
        private ConferenteServices _conferenteServices;
        private EntregadorServices _entregadorServices;

        public LoginController(Context context, ConferenteServices conferenteServices, EntregadorServices entregadorServices)
        {
            _context = context;
            _conferenteServices = conferenteServices;
            _entregadorServices = entregadorServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logar(Conferente conferente)
        {
            Conferente conferente1 = _conferenteServices.Logar(conferente.login, conferente.senha);
            if (conferente == null)
            {
                Validation<Conferente>.CopyValidation(this.ModelState, _conferenteServices);
                return View("Index");
            }
            else
            {
                return RedirectToAction("Index","Principal");
            }
        }
        [HttpGet]
        public IActionResult CadastrarConferente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarConferente(Conferente conferente)
        {
            _conferenteServices.CadastrarConferente(conferente);
            return RedirectToAction("login_conferente");
        }

    }
}
