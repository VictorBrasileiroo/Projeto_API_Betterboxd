using System.ComponentModel.DataAnnotations;
using Betterboxd.App.Dtos;
using Betterboxd.App.Interfaces;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Betterboxd.API.Controllers
{
    [Route("api/v1/avaliacoes")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _service;
        public AvaliacaoController(IAvaliacaoService service) => _service = service;

        /// <summary>
        /// Lista todas as avaliações cadastradas no sistema.
        /// </summary>
        /// <returns>Retorna todas as avaliações ou mensagem de erro.</returns>
        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var response = await _service.ListarTodos();

                if (!response.Any())
                {
                    return NotFound(new ResponseModel<List<AvaliacaoModel>>(false, "Nenhuma avaliação encontrada!", null));
                }

                return Ok(new ResponseModel<List<AvaliacaoModel>>(true, "Avaliações listadas com sucesso!", response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        /// <summary>
        /// Busca uma avaliação específica pelo ID.
        /// </summary>
        /// <param name="id">ID da avaliação.</param>
        /// <returns>Retorna a avaliação encontrada ou mensagem de erro.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var response = await _service.BuscarPorId(id);

                if (response == null)
                {
                    return NotFound(new ResponseModel<AvaliacaoModel>(false, "Nenhuma avaliação encontrada!", null));
                }

                return Ok(new ResponseModel<AvaliacaoModel>(true, "Avaliação encontrada com sucesso!", response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        /// <summary>
        /// Lista todas as avaliações feitas por um usuário específico.
        /// </summary>
        /// <param name="idUser">ID do usuário.</param>
        /// <returns>Retorna as avaliações do usuário ou mensagem de erro.</returns>
        [HttpGet("users/{idUser}")]
        public async Task<IActionResult> ListarPorIdUser(int idUser)
        {
            try
            {
                var response = await _service.ListarPorIdUser(idUser);

                if (!response.Any())
                {
                    return NotFound(new ResponseModel<List<AvaliacaoModel>>(false, "Nenhuma avaliação encontrada!", null));
                }

                return Ok(new ResponseModel<List<AvaliacaoModel>>(true, "Avaliações encontradas com sucesso!", response));
            }
            catch (KeyNotFoundException exc)
            {
                return StatusCode(404, new ResponseModel<string>(false, "Usuário não encontrado", exc.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        /// <summary>
        /// Remove uma avaliação específica.
        /// </summary>
        /// <param name="id">ID da avaliação a ser removida.</param>
        /// <returns>Retorna confirmação de remoção ou mensagem de erro.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverAvaliacao(int id)
        {
            try
            {
                var response = await _service.RemoverAvaliacao(id);

                if (response == null)
                {
                    return NotFound(new ResponseModel<AvaliacaoModel>(false, "Nenhuma avaliação encontrada!", null));
                }

                return Ok(new ResponseModel<AvaliacaoModel>(true, "Avaliações removida com sucesso!", response));
            }
            catch (KeyNotFoundException exc)
            {
                return StatusCode(404, new ResponseModel<string>(false, "Avaliação não encontrado", exc.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        /// <summary>
        /// Cadastra uma nova avaliação.
        /// </summary>
        /// <param name="dto">Objeto contendo os dados da nova avaliação.</param>
        /// <returns>Retorna a avaliação cadastrada ou mensagem de erro.</returns>
        [HttpPost]
        public async Task<IActionResult> CadastrarAvaliacao(AvaliacaoCriarDto dto)
        {
            try
            {
                var response = await _service.CadastrarAvaliacao(dto);
                return Ok(new ResponseModel<AvaliacaoModel>(true, "Avaliação cadastrada com sucesso!", response));
            }
            catch (ValidationException exc)
            {
                return StatusCode(400, new ResponseModel<string>(false, "Erro de validação", exc.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        /// <summary>
        /// Edita uma avaliação existente.
        /// </summary>
        /// <param name="dto">Objeto contendo os dados atualizados da avaliação.</param>
        /// <param name="id">ID da avaliação a ser editada.</param>
        /// <returns>Retorna a avaliação editada ou mensagem de erro.</returns>
        [HttpPut]
        public async Task<IActionResult> EditarAvaliacao(AvaliacaoEditarDto dto, int id)
        {
            try
            {
                var response = await _service.EditarAvaliacao(dto, id);
                return Ok(new ResponseModel<AvaliacaoModel>(true, "Avaliação editada com sucesso!", response));
            }
            catch (ValidationException exc)
            {
                return StatusCode(400, new ResponseModel<string>(false, "Erro de validação", exc.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(404, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }
    }
}
