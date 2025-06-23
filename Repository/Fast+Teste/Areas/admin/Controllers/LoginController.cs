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
        public IActionResult login_conferente(Conferente conferente)
        {
            Conferente conferente1 = _conferenteServices.Logar(conferente.login, conferente.senha);
            if (conferente == null)
            {
                Validation<Conferente>.CopyValidation(this.ModelState, _entregadorServices);
                return View("login_entregador");
            }
            else
            {
                return RedirectToAction("Index", "Principal");
            }
        }
        public IActionResult login_entregador(Entregador entregador)
        {
            Entregador entregador1 = _entregadorServices.Logar(entregador.login, entregador.senha);
            if (entregador1 == null){
                Validation<Entregador>.CopyValidation(this.ModelState, _entregadorServices);
                return View("login_entregador");
            }
            else
            {
                return RedirectToAction("Index", "Principal");
            }   
        }

        // Cadastro de Conferente
        [HttpGet]
        public IActionResult CadastrarConferente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarConferente(Conferente conferente)
        {
            _conferenteServices.Cadastrar(conferente);
            return RedirectToAction("login_conferente");
        }

        // Cadastro de Entregador
        [HttpGet]
        public IActionResult CadastrarEntregador()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarEntregador(Entregador entregador)
        {
            _entregadorServices.Cadastrar(entregador);
            return RedirectToAction("login_entregador");
        }
    }
}
