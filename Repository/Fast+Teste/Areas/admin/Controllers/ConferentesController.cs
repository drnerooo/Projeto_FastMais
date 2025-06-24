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
    public class ConferentesController : Controller
    {
        private Context _context;
        private ConferenteServices _conferenteServices;

        public ConferentesController(Context context)
        {
            _context = context;
            _conferenteServices = new ConferenteServices(new GenericRepository<Conferente>(context), context);
        }
        // GET: ConferentesController
        public ActionResult Index()
        {
            List<Conferente> conferentes = _conferenteServices.GetAll().OrderBy(c => c.nome).ToList();
            return View(conferentes);
        }

        // GET: ConferentesController/Details/5
        public ActionResult Details(int id)
        {
            var conferente = _conferenteServices.GetById(id);
            if (conferente == null)
                return NotFound();

            return View(conferente);
        }

        // GET: ConferentesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConferentesController/Create
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

        // GET: ConferentesController/Edit/5
        public ActionResult Edit(int id)
        {
            var conferente = _conferenteServices.GetById(id);
            if (conferente == null)
                return NotFound();

            return View(conferente);
        }

        // POST: ConferentesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Conferente conferente)
        {
                try
                {
                    if (_conferenteServices.Update(conferente))
                    {
                        Validation<Conferente>.CopyValidation(ModelState, _conferenteServices);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View(conferente);
                    }
                }
                catch
                {
                    return View(conferente);
                }
        }

        // GET: ConferentesController/Delete/5
        public ActionResult Delete(int id)
        {
            var conferente = _conferenteServices.GetById(id);
            if (conferente == null)
                return NotFound();

            return View(conferente);
        }

        // POST: ConferentesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var conferente = _conferenteServices.GetById(id);
                _conferenteServices.Delete(conferente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
