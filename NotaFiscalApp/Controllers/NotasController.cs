using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NotaFiscalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : Controller
    {
        private readonly INotaFiscalService _service;   

        public NotasController(                        
             INotaFiscalService service
            )
        {      
            _service = service;
        }

        /// <summary>
        /// Endpoint para salvar as notas.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(NotaFiscalCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Numero) || string.IsNullOrWhiteSpace(dto.Cliente) || dto.Valor <= 0 || dto.DataEmissao == default)
                return BadRequest(new { message = "Campos obrigatórios inválidos" });

            await _service.CadastrarAsync(dto);
       
            return Ok(new { message = "Nota cadastrada com sucesso" });
        }

        /// <summary>
        /// Endpoint para listar as notas.
        /// </summary>
        /// <returns></returns>
        [HttpGet]   
        public async Task<IActionResult> Get(string? nomeCliente, bool ordenarValor = false)
        {
            var listNotasFiscais = await _service.ListarAsync(nomeCliente, ordenarValor);
               
            return PartialView("~/Views/Home/_PartialTabelaNotas.cshtml", listNotasFiscais);          
        }
    }
}
