using System.Threading.Tasks;
using BrasilSincero.Core;
using BrasilSincero.Model;
using Microsoft.AspNetCore.Mvc;

namespace BrasilSincero.Controllers
{
    [Route("dados-gov")]
    public class DadosGovController : Controller
    {
        private readonly ProcessCore _processCore;

        public DadosGovController(ProcessCore processCore)
        {
            _processCore = processCore;
        }
        [HttpPost]
        [Route("capturar-periodo")]
        public async Task<IActionResult> BaixarUmPerido([FromBody] FiltroDados filtroDados)
        {
            var result = _processCore.BaixarDados(filtroDados);

            return Ok();

        }        
    }
}