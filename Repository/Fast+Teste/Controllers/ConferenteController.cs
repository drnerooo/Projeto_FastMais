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

        public ConferenteController(Context context)
        {
            _context = context;
            _conferenteServices = new ConferenteServices(new GenericRepository<Conferente>(context));
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
