using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Validation;
using Services;
using Repository.Repositories;
using Fast_Teste.Util;
using Repository.EF;
namespace Fast_Teste.Controllers
{
    public class EntregadorController : Controller
    {
        private EntregadorServices _entregadorServices;
        private Context _context;
        private EntregaServices _entregaservices;
        public EntregadorController(Context context)
        {
            _context = context;
            _entregadorServices = new EntregadorServices(new EntregadorRepository(context), context);
            _entregaservices = new EntregaServices(new GenericRepository<Entrega>(_context));

        }
        public IActionResult IndexEntregador()
        {
            return View();
        }
        public IActionResult login_entregador()
        {
            return View();
        }
        public IActionResult criar_login_entregador()
        {
            return View();
        }
        public IActionResult Logar(Entregador entregador)
        {
            Entregador entregador1 = _entregadorServices.Logar(entregador.login, entregador.senha);
            if (entregador1 == null)
            {
                Validation<Entregador>.CopyValidation(this.ModelState, _entregadorServices);
                return View("Index");
            }
            else
            {
                return RedirectToAction("IndexEntregador");
            }
        }
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
        [HttpGet]
        public IActionResult Pendentes()
        {
            var entregas = _entregaservices.GetPendentes();
            return View(entregas);
        }
        [HttpPost]
        public IActionResult Aceitar(int id)
        {
            _entregaservices.AceitarEntrega(id);
            return RedirectToAction("Pendentes");
        }

        [HttpPost]
        public IActionResult Recusar(int id)
        {
            _entregaservices.RecusarEntrega(id);
            return RedirectToAction("Pendentes");
        }

        [HttpGet]
        public IActionResult Atuais()
        {
            var entregas = _entregaservices.GetAceitas();
            return View(entregas);
        }
    }
}
