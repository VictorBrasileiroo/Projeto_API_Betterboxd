using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Interfaces;
using Betterboxd.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Betterboxd.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext contex) => _context = contex;

        public async Task<UserModel> Create(UserModel user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> Delete(UserModel user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserModel>> GetAll() => await _context.Usuários.ToListAsync();

        public async Task<UserModel> GetById(int id) => await _context.Usuários.FindAsync(id);

        public async Task<UserModel> Update(UserModel user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
