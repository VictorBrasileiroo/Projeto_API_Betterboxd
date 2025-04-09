using Betterboxd.App.Interfaces;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Betterboxd.API.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service) => _service = service;

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

    }
}
