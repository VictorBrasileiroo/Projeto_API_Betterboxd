using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.App.Dtos;
using Betterboxd.App.Interfaces;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Betterboxd.App.Services
{
    public class FilmeServices : IFilmeServices
    {
        private readonly IFilmeRepository _repository;
        public FilmeServices(IFilmeRepository repository) => _repository = repository;

        public async Task<FilmeModel> BuscarPorId(int id)
        {
            var response = await _repository.GetById(id);
            return response;
        }

        public Task<FilmeCriarDto> CadastrarFilme(FilmeCriarDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<FilmeEditarDto> EditarFilme(FilmeEditarDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FilmeModel>> ListarPorAnoLancamento(int ano)
        {
            var response = await _repository.GetByYear(ano);
            return response;
        }

        public async Task<List<FilmeModel>> ListarPorDiretor(string diretor)
        {
            var response = await _repository.GetByDirector(diretor);
            return response;
        }

        public async Task<List<FilmeModel>> ListarPorGenero(string genero)
        {
            var response = await _repository.GetByGender(genero);
            return response;
        }

        public async Task<List<FilmeModel>> ListarTodos()
        {
            var response = await _repository.GetAll();
            return response;
        }

        public async Task<FilmeModel> RemoverFilme(int id)
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
