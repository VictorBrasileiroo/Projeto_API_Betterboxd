using Betterboxd.App.Interfaces;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
                var response = await _services.ListarTodos();
                if (!response.Any())
                {
                    return NotFound(new ResponseModel<List<FilmeModel>>(false, "Nenhum filme encontrado!", null));
                }

                return Ok(new ResponseModel<List<FilmeModel>>(true, "Todos os filmes listados com sucesso!", response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var response = await _services.BuscarPorId(id);
                if (response == null)
                {
                    return NotFound(new ResponseModel<FilmeModel>(false, "Nenhum filme encontrado!", null));
                }

                return Ok(new ResponseModel<FilmeModel>(true, "Filme encontrado com sucesso!", response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        [HttpGet("diretor/{diretor}")]
        public async Task<IActionResult> ListarPorDiretor(string diretor)
        {
            try
            {
                var response = await _services.ListarPorDiretor(diretor);
                if (response.IsNullOrEmpty())
                {
                    return NotFound(new ResponseModel<List<FilmeModel>>(false, "Nenhum filme encontrado!", null));
                }

                return Ok(new ResponseModel<List<FilmeModel>>(true, "Filmes encontrados com sucesso!", response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        [HttpGet("genero/{genero}")]
        public async Task<IActionResult> ListarPorGenero(string genero)
        {
            try
            {
                var response = await _services.ListarPorGenero(genero);
                if (response.IsNullOrEmpty())
                {
                    return NotFound(new ResponseModel<List<FilmeModel>>(false, "Nenhum filme encontrado!", null));
                }

                return Ok(new ResponseModel<List<FilmeModel>>(true, "Filmes encontrados com sucesso!", response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        [HttpGet("ano/{ano}")]
        public async Task<IActionResult> ListarPorAnoLancamento(int ano)
        {
            try
            {
                var response = await _services.ListarPorAnoLancamento(ano);
                if (response.IsNullOrEmpty())
                {
                    return NotFound(new ResponseModel<List<FilmeModel>>(false, "Nenhum filme encontrado!", null));
                }

                return Ok(new ResponseModel<List<FilmeModel>>(true, "Filmes encontrados com sucesso!", response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverFilme(int id)
        {
            try
            {
                var response = await _services.RemoverFilme(id);
                if (response == null)
                {
                    return NotFound(new ResponseModel<FilmeModel>(false, "Filme não encontrado!", null));
                }

                return Ok(new ResponseModel<FilmeModel>(true, "Filmes removido com sucesso!", response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

    }
}
