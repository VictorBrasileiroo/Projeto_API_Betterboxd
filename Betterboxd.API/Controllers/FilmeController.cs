using Betterboxd.App.Interfaces;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Betterboxd.API.Controllers
{
    [Route("api/v1/filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeServices _services;
        public FilmeController(IFilmeServices services) => _services = services;

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var reponse = await _services.ListarTodos();
                if (!reponse.Any())
                {
                    return NotFound(new ResponseModel<List<FilmeModel>>(false, "Nenhum filme encontrado!", null));
                }

                return Ok(new ResponseModel<List<FilmeModel>>(true, "Todos os filmes listados com sucesso!", reponse));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }
    }
}
