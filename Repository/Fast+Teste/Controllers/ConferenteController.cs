using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Validation;
using Services;
using Fast_Teste.Util;
using Repository.EF;
using Repository.Repositories;

namespace Fast_Teste.Controllers
{
    public class ConferenteController : Controller
    {
        private Context _context;
        private ConferenteServices _conferenteServices;
        private EntregaServices _entregaservices;

        public ConferenteController(Context context)
        {
            _context = context;
            _conferenteServices = new ConferenteServices(new GenericRepository<Conferente>(context), context);
            _entregaservices = new EntregaServices(new GenericRepository<Entrega>(_context));
        }
        public IActionResult Index()
        {
            List<Conferente> conferentes = _conferenteServices.GetAll().OrderBy(x=>x.login).ToList();
            return View();
        }

        public IActionResult login_conferente()
        {
            return View();
        }

        public IActionResult criar_login_conferente()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Conferente conferente)
        {
            try
            {
                if (_conferenteServices.Insert(conferente))
                {
                    Validation<Conferente>.CopyValidation(ModelState, _conferenteServices);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Relatorio()
        {
            return View();
        }
        public IActionResult AdicionarProduto()
        {
            return View();
        }
        public IActionResult CriarProduto()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Logar()
        {
            return View();
        }
        [HttpPost]
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
                return RedirectToAction("Index");
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
