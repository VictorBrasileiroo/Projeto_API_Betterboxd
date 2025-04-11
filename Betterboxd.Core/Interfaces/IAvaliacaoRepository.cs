using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.Core.Entities;

namespace Betterboxd.Core.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<List<AvaliacaoModel>> GetAll();
        Task<AvaliacaoModel> GetById(int id);
        Task<List<AvaliacaoModel>> GetAllByUserId(int idUser);
        Task<List<AvaliacaoModel>> GetAllByFilmId(int idFilm);
        Task<AvaliacaoModel> CalcularNotaMediaFilme(int idFilm);
        Task<AvaliacaoModel> Create(AvaliacaoModel user);
        Task<AvaliacaoModel> Update(AvaliacaoModel user);
        Task<AvaliacaoModel> Delete(AvaliacaoModel user);
    }
}
