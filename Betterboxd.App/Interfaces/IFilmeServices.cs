using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.App.Dtos;
using Betterboxd.Core.Entities;

namespace Betterboxd.App.Interfaces
{
    public interface IFilmeServices
    {
        Task<List<FilmeModel>> ListarTodos();
        Task<FilmeModel> BuscarPorId(int id);
        Task<List<FilmeModel>> ListarPorDiretor(string diretor);
        Task<List<FilmeModel>> ListarPorGenero(string genero);
        Task<List<FilmeModel>> ListarPorAnoLancamento(int ano);
        Task<FilmeCriarDto> CadastrarFilme(FilmeCriarDto dto);
        Task<FilmeEditarDto> EditarFilme(FilmeEditarDto dto);
        Task<FilmeModel> RemoverFilme(int id);
    }
}
