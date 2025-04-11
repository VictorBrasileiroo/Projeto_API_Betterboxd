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
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly AppDbContext _context;
        public AvaliacaoRepository(AppDbContext context) => _context = context;

        public async Task<decimal> CalcularNotaMediaFilme(int idFilm)
        {
            var media = await _context.Avaliações
                .Where(a => a.IdFilme == idFilm)
                .Select(a => (decimal?)a.Nota)
                .AverageAsync();

            return media ?? 0m;
        }

        public async Task<AvaliacaoModel> Create(AvaliacaoModel avaliacao)
        {
            _context.Add(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao;
        }

        public async Task<AvaliacaoModel> Delete(AvaliacaoModel avaliacao)
        {
            _context.Remove(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao;
        }

        public async Task<List<AvaliacaoModel>> GetAll() => await _context.Avaliações.ToListAsync();

        public async Task<List<AvaliacaoModel>> GetAllByFilmId(int idFilm) => await _context.Avaliações.Where(a => a.IdFilme == idFilm).ToListAsync();

        public async Task<List<AvaliacaoModel>> GetAllByUserId(int idUser) => await _context.Avaliações.Where(a => a.IdUser == idUser).ToListAsync();

        public async Task<AvaliacaoModel> GetById(int id) => await _context.Avaliações.FindAsync(id);

        public async Task<AvaliacaoModel> Update(AvaliacaoModel avaliacao)
        {
            _context.Update(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao;
        }
    }
}
