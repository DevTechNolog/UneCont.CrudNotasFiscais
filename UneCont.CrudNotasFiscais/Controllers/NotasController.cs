using Microsoft.AspNetCore.Mvc;

namespace UneCont.CrudNotasFiscais.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : Controller
    {
        //private readonly INotaService _service;

        //public NotasController(INotaService service)
        //{
        //    _service = service;
        //}

        //[HttpPost]
        //public ActionResult Post(NotaFiscalCreateDto dto)
        //{
        //    // validação simples (server-side)
        //    if (string.IsNullOrWhiteSpace(dto.Numero) ||
        //    string.IsNullOrWhiteSpace(dto.Cliente) ||
        //    dto.Valor <= 0 ||
        //    dto.DataEmissao == default)
        //    {
        //        return BadRequest(new { message = "Campos obrigatórios inválidos" });
        //    }


        //    var nota = _service.AddNota(dto);
        //    return CreatedAtAction(null, new { id = nota.Id });
        //}


        //[HttpGet]
        //public ActionResult<IEnumerable<NotaFiscalListDto>> Get()
        //{
        //    var list = _service.GetAll();
        //    return Ok(list);
        //}
    }
}
