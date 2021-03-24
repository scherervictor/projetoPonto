using ApiTeste.Application.Dtos;
using ApiTeste.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTeste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PontoController : ControllerBase
    {
        private readonly IPontoService _pontoService;

        public PontoController(IPontoService pontoService)
        {
            _pontoService = pontoService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> RegistrarPonto([FromBody]RegistrarPontoDto registrarPontoDto)
        {
            await _pontoService.RegistrarPonto(registrarPontoDto);

            return Ok();
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarPontos()
        {
            var result = await _pontoService.ListarPontos();

            if (result.Any())
                return Ok(result);
            else
                return BadRequest("Não foram encontrados registros");
        }
    }
}
