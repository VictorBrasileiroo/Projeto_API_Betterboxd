using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.App.Dtos;
using Betterboxd.App.Interfaces;
using Betterboxd.App.Validations;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Interfaces;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Betterboxd.App.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository) => _repository = repository; 

        public async Task<UserModel> BuscarPorId(int id)
        {
            var response = await _repository.GetById(id);
            return response;
        }

        public async Task<UserModel> CadastrarUser(UserCriaDto dto)
        {

            var validator = new UserCriarValidator();
            var result = validator.Validate(dto);

            if (!result.IsValid)
            {
                var erros = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(erros);
            }

            var user = new UserModel()
            {
                Nome = dto.Nome,
                Email = dto.Email
            };

            var response = await _repository.Create(user);
            return response;
        }

        public async Task<UserModel> EditarUser(UserEditarDto dto, int id)
        {
            var user = await _repository.GetById(id);
            if (user == null) throw new Exception("Usuário não encontrado");

            var validator = new UserEditarValidator();
            var result = validator.Validate(dto);

            if(dto.Email == "string")
            {
                if (!result.IsValid)
                {
                    var erros = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                    throw new ValidationException(erros);
                }
            }
            
            AtualizarCampoSeMudou(user.Nome,dto.Nome, novoValor => user.Nome = novoValor);
            AtualizarCampoSeMudou(user.Email,dto.Email, novoValor => user.Email = novoValor);

            var response = await _repository.Update(user);
            return response;
        }

        public async Task<List<UserModel>> ListarTodos()
        {
            var response = await _repository.GetAll();
            return response;
        }

        public async Task<UserModel> RemoverUser(int id)
        {
            var response = await _repository.GetById(id);

            if (response != null)
            {
                await _repository.Delete(response);
            }

            return response;

        }

        private void AtualizarCampoSeMudou<T>(T campoAtual, T novoValor, Action<T> atualizarCampo)
        {
            if (novoValor != null && !Equals(campoAtual, novoValor) && !Equals(novoValor, "string"))
            {
                atualizarCampo(novoValor);
            }
        }
    }
}
