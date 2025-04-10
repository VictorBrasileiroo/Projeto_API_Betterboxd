using System.ComponentModel.DataAnnotations;
using Betterboxd.App.Dtos;
using Betterboxd.App.Interfaces;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Betterboxd.API.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações relacionadas aos usuários.
    /// </summary>
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        /// <summary>
        /// Construtor da classe UserController.
        /// </summary>
        /// <param name="service">Serviço responsável pela lógica de negócios dos usuários.</param>
        public UserController(IUserService service) => _service = service;

        /// <summary>
        /// Lista todos os usuários cadastrados.
        /// </summary>
        /// <returns>Uma lista com todos os usuários cadastrados.</returns>
        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var response = await _service.ListarTodos();
                if (!response.Any())
                {
                    return NotFound(new ResponseModel<List<UserModel>>(false, "Nenhum usuário encontrado!", null));
                }

                return Ok(new ResponseModel<List<UserModel>>(true, "Todos os usuários listados com sucesso!", response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        /// <summary>
        /// Lista um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser buscado.</param>
        /// <returns>O usuário correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var response = await _service.BuscarPorId(id);
                if (response == null)
                {
                    return NotFound(new ResponseModel<UserModel>(false, "Nenhum usuário encontrado!", null));
                }

                return Ok(new ResponseModel<UserModel>(true, "Usuário encontrado com sucesso!", response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        /// <summary>
        /// Remove um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser removido.</param>
        /// <returns>Resultado da operação de remoção.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverUsuario(int id)
        {
            try
            {
                var response = await _service.RemoverUser(id);
                if (response == null)
                {
                    return NotFound(new ResponseModel<UserModel>(false, "Nenhum usuário encontrado!", null));
                }

                return Ok(new ResponseModel<UserModel>(true, "Usuário removido com sucesso!", response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<string>(false, "Erro interno", ex.Message));
            }
        }

        /// <summary>
        /// Cadastra um novo usuário no sistema.
        /// </summary>
        /// <param name="dto">Dados necessários para a criação do novo usuário.</param>
        /// <returns>Resultado da operação de cadastro.</returns>
        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(UserCriaDto dto)
        {
            try
            {
                var response = await _service.CadastrarUser(dto);
                return Ok(new ResponseModel<UserModel>(true, "Usuário cadastrado com sucesso!", response));
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, new ResponseModel<string>(false, "Erro de validação", ex.Message));
            }
        }

        /// <summary>
        /// Edita os dados de um usuário existente.
        /// </summary>
        /// <param name="dto">Dados atualizados do usuário.</param>
        /// <param name="id">ID do usuário a ser editado.</param>
        /// <returns>Resultado da operação de edição.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarUsuario(UserEditarDto dto, int id)
        {
            try
            {
                var response = await _service.EditarUser(dto, id);
                return Ok(new ResponseModel<UserModel>(true, "Usuário editado com sucesso!", response));
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, new ResponseModel<string>(false, "Erro de validação", ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(404, new ResponseModel<string>(false, "Erro ao encontrar o usuario", ex.Message));
            }
        }
    }
}
