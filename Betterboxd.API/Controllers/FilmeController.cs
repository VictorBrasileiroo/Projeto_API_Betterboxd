using System.ComponentModel.DataAnnotations;
using Betterboxd.App.Dtos;
using Betterboxd.App.Interfaces;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Betterboxd.API.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar operações relacionadas aos filmes, como listar, buscar, cadastrar, editar e remover.
    /// </summary>
    [Route("api/v1/filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeServices _services;

        /// <summary>
        /// Construtor que injeta o serviço de filmes.
        /// </summary>
        /// <param name="services">Serviço responsável pelas operações com filmes.</param>
        public FilmeController(IFilmeServices services) => _services = services;

        /// <summary>
        /// Lista todos os filmes cadastrados.
        /// </summary>
        /// <returns>Retorna todos os filmes existentes.</returns>
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

        /// <summary>
        /// Busca um filme pelo ID.
        /// </summary>
        /// <param name="id">ID do filme a ser buscado.</param>
        /// <returns>Retorna o filme correspondente ao ID informado.</returns>
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

        /// <summary>
        /// Lista os filmes com base no nome do diretor.
        /// </summary>
        /// <param name="diretor">Nome do diretor.</param>
        /// <returns>Retorna os filmes dirigidos pelo diretor informado.</returns>
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

        /// <summary>
        /// Lista os filmes com base no gênero.
        /// </summary>
        /// <param name="genero">Gênero do filme.</param>
        /// <returns>Retorna os filmes que pertencem ao gênero informado.</returns>
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

        /// <summary>
        /// Lista os filmes lançados em um determinado ano.
        /// </summary>
        /// <param name="ano">Ano de lançamento.</param>
        /// <returns>Retorna os filmes lançados no ano informado.</returns>
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

        /// <summary>
        /// Remove um filme com base no ID.
        /// </summary>
        /// <param name="id">ID do filme a ser removido.</param>
        /// <returns>Retorna o filme removido.</returns>
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

        /// <summary>
        /// Cadastra um novo filme no sistema.
        /// </summary>
        /// <param name="dto">Dados do filme a ser cadastrado.</param>
        /// <returns>Retorna o filme cadastrado.</returns>
        [HttpPost]
        public async Task<IActionResult> CadastrarFilme(FilmeCriarDto dto)
        {
            try
            {
                var response = await _services.CadastrarFilme(dto);
                return Ok(new ResponseModel<FilmeModel>(true, "Filmes cadastrado com sucesso!", response));
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, new ResponseModel<string>(false, "Erro de validação", ex.Message));
            }
        }

        /// <summary>
        /// Edita um filme existente no sistema.
        /// </summary>
        /// <param name="dto">Dados atualizados do filme.</param>
        /// <returns>Retorna o filme editado.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarFilme(FilmeEditarDto dto)
        {
            try
            {
                var response = await _services.EditarFilme(dto);
                return Ok(new ResponseModel<FilmeModel>(true, "Filmes Editado com sucesso!", response));
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, new ResponseModel<string>(false, "Erro de validação", ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(404, new ResponseModel<string>(false, "Erro ao encontrar o filme", ex.Message));
            }
        }
    }
}
