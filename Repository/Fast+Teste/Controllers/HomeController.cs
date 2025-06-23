using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fast_Teste.Models;
using Repository.EF;
using Services;
using Repository.Repositories;
using Business.Models;

namespace Fast_Teste.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private Context _context;
    private ConferenteServices _conferenteServices;
    private EntregadorServices _entregadorServices;
    private EntregaServices _entregaServices;
    private ProdutoEntregaServices _produtoEntregaServices;
    private ProdutoServices _produtoServices;
    public HomeController(Context context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
        _conferenteServices = new ConferenteServices(new ConferenteRepository(context));
    }

    public IActionResult Index()
    {
        List<Conferente> conferentes = _conferenteServices.GetAll().OrderBy(x=>x.id).ToList();
        ViewBag.Conferentes = conferentes;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
