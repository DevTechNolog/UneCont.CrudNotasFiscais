using Application.DTOs;
using Application.Interfaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NotaFiscalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : Controller
    {
        private readonly ILogger<NotasController> _logger;
        private readonly INotaFiscalService _service;   

        public NotasController(
             ILogger<NotasController> logger,
             INotaFiscalService service
            )
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Endpoint para salvar novas notas.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(NotaFiscalCreateDto dto)
        {
            try
            {              
                await _service.CadastrarAsync(dto);

                return Ok(new { message = "Nota cadastrada com sucesso" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar nota.");
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Endpoint para listar as notas cadastradas.
        /// </summary>
        /// <returns></returns>
        [HttpGet]   
        public async Task<IActionResult> Get(string? nomeCliente = null, string? numeroNota = null, bool? ordenarValor = null)
        {
            List<NotaFiscalViewModel> listNotasFiscais = new();
            try
            {
                listNotasFiscais = await _service.ListarAsync(nomeCliente, numeroNota, ordenarValor);               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao carregar a lista de notas fiscais.");
            }
            return PartialView("~/Views/Home/_PartialTabelaNotas.cshtml", listNotasFiscais);
        }
    }
}
