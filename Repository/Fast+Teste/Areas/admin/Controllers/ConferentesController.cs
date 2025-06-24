using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Business;
using Repository.Repositories;
using Repository.EF;
using Business.Models;

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
            _conferenteServices = new ConferenteServices(new GenericRepository<Conferente>(context));
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
            return View();
        }

        // GET: ConferentesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConferentesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConferentesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConferentesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConferentesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConferentesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
