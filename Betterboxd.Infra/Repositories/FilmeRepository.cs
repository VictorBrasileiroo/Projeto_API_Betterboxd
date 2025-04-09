using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Interfaces;
using Betterboxd.Infra.Context;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Betterboxd.Infra.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly AppDbContext _context;
        public FilmeRepository(AppDbContext contex) => _context = contex;

        public async Task<FilmeModel> Create(FilmeModel filme)
        {
            _context.Add(filme);
            await _context.SaveChangesAsync();
            return filme;
        }

        public async Task<FilmeModel> Delete(FilmeModel filme)
        {
            _context.Remove(filme);
            await _context.SaveChangesAsync();
            return filme;
        }

        public async Task<List<FilmeModel>> GetAll() => await _context.Filmes.ToListAsync();

        public async Task<List<FilmeModel>> GetByDirector(string director)
        {
            var response = await _context.Filmes
                 .Where(f => f.Diretor.ToLower().Trim() == director.ToLower().Trim())
                 .ToListAsync();

            return response;
        }

        public async Task<List<FilmeModel>> GetByGender(string gender)
        {
            var response = await _context.Filmes
                 .Where(f => f.Genero.ToLower().Trim() == gender.ToLower().Trim())
                 .ToListAsync();

            return response;
        }

        public async Task<FilmeModel> GetById(int id) => await _context.Filmes.FindAsync(id);

        public async Task<List<FilmeModel>> GetByYear(int year)
        {
            var response = await _context.Filmes
            .Where(f => f.DataLancamento.Year == year)
            .ToListAsync();

            return response;
        }

        public async Task<FilmeModel> Update(FilmeModel filme)
        {
            _context.Update(filme);
            await _context.SaveChangesAsync();
            return filme;
        }
    }
}
