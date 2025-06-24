using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Fast_Teste.Controllers
{
    [Area("Entregador")]
    [Authorize] // Adicionando autenticação para obter o ID do entregador logado
    public class EntregaController : Controller
    {
        private readonly EntregaServices _entregaServices;

        public EntregaController(EntregaServices entregaServices)
        {
            _entregaServices = entregaServices;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Entrega entrega)
        {
            if (_entregaServices.Insert(entrega))
            {
                return RedirectToAction("Index", "Home"); // ou outra tela
            }

            return View(entrega);
        }

        public IActionResult Pendentes()
        {
            var entregas = _entregaServices.GetPendentes();
            return View(entregas);
        }

        public IActionResult Relatorio()
        {
            // Obtendo o ID do entregador logado
            var entregadorID = int.Parse(User.FindFirst("EntregadorID")?.Value ?? "0");

            if (entregadorID == 0)
            {
                return Unauthorized(); // Retorna erro caso o ID não seja encontrado
            }

            var entregas = _entregaServices.GetConcluidasPorEntregador(entregadorID);
            return View(entregas);
        }
    }
}
