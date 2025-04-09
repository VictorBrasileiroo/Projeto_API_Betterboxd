using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.Core.Entities;

namespace Betterboxd.Core.Interfaces
{
    public interface IFilmeRepository
    {
        Task<List<FilmeModel>> GetAll();
        Task<FilmeModel> GetById(int id);
        Task<List<FilmeModel>> GetByGender(string gender);
        Task<List<FilmeModel>> GetByDirector(string director);
        Task<List<FilmeModel>> GetByYear(int year);
        Task<FilmeModel> Create(FilmeModel filme);
        Task<FilmeModel> Update(FilmeModel filme);
        Task<FilmeModel> Delete(FilmeModel filme);
    }
}
