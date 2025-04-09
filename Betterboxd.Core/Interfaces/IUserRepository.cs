using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.Core.Entities;

namespace Betterboxd.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetById(int id);
        Task<UserModel> Create(UserModel user);
        Task<UserModel> Update(UserModel user);
        Task<UserModel> Delete(UserModel user);
    }
}
