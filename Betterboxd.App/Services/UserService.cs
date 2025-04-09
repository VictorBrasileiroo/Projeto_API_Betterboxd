using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.App.Dtos;
using Betterboxd.App.Interfaces;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Interfaces;

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

        public Task<UserModel> CadastrarUser(UserCriaDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> EditarUser(UserEditarDto dto)
        {
            throw new NotImplementedException();
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
    }
}
