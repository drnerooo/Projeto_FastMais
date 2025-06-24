using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Business;
using Repository.Repositories;
using Repository.EF;
using Business.Models;
using Services.Validation;
using Fast_Teste.Util;


namespace Fast_Teste.Areas.admin.Controllers
{
    [Area("admin")]
    public class EntregadoresController : Controller
    {
        private Context _context;
        private EntregadorServices _entregadorservices;

        public EntregadoresController(Context context)
        {
            _context = context;
            _entregadorservices = new EntregadorServices(new GenericRepository<Entregador>(context));
        }
        // GET: EntregadorController
        public ActionResult Index()
        {
            List<Entregador> entregadores = _entregadorservices.GetAll().OrderBy(c => c.nome).ToList();
            return View(entregadores);
        }

        // GET: EntregadorController/Details/5
        public ActionResult Details(int id)
        {
            var entregador = _entregadorservices.GetById(id);
            if (entregador == null)
                return NotFound();

            return View(entregador);
        }

        // GET: EntregadorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntregadorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Entregador entregador)
        {
            try
            {
                if (_entregadorservices.Insert(entregador))
                {
                    Validation<Entregador>.CopyValidation(ModelState, _entregadorservices);
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
        // GET: EntregadorController/Edit/5
        public ActionResult Edit(int id)
        {
            var entregador = _entregadorservices.GetById(id);
            if (entregador == null)
                return NotFound();

            return View(entregador);
        }

        // POST: EntregadorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Entregador entregador)
        {
            try
            {
                if (_entregadorservices.Update(entregador))
                {
                    Validation<Entregador>.CopyValidation(ModelState, _entregadorservices);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(entregador);
                }
            }
            catch
            {
                return View(entregador);
            }
        }

        // GET: EntregadorController/Delete/5
        public ActionResult Delete(int id)
        {
            var entregador = _entregadorservices.GetById(id);
            if (entregador == null)
                return NotFound();

            return View(entregador);
        }

        // POST: EntregadorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var entregador = _entregadorservices.GetById(id);
                _entregadorservices.Delete(entregador);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Index);
            }
        }
    }
}
