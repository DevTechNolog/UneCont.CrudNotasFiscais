using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NotaFiscalApp.Models;
using System.Diagnostics;

namespace NotaFiscalApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;  
        private readonly INotaFiscalService _notaFiscalService;

        public HomeController(
            ILogger<HomeController> logger,     
            INotaFiscalService notaFiscalService)
        {
            _logger = logger; 
            _notaFiscalService = notaFiscalService;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var listNotasFiscais = await _notaFiscalService.ListarAsync();

                return View(listNotasFiscais);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar a lista de notas fiscais.");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }               
        }    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
