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
            _entregadorServices = new EntregadorServices(new EntregadorRepository(context));
            _entregaservices = new EntregaServices(new GenericRepository<EntregaServices>(context), context);
        }
        public IActionResult Index()
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
                return RedirectToAction("Index", "Principal");
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
        public IActionResult Pendentes()
        {
            var entregas = _entregaservices.GetPendentes();
            return View(entregas);
        }
    }
}
