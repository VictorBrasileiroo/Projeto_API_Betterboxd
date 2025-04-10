using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.App.Dtos;
using Betterboxd.Core.Entities;

namespace Betterboxd.App.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> ListarTodos();
        Task<UserModel> BuscarPorId(int id);
        Task<UserModel> CadastrarUser(UserCriaDto dto);
        Task<UserModel> EditarUser(UserEditarDto dto, int id);
        Task<UserModel> RemoverUser(int id);
    }
}
