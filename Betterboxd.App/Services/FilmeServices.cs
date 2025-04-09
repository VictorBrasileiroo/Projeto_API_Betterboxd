using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.App.Dtos;
using Betterboxd.App.Interfaces;
using Betterboxd.App.Validations;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Interfaces;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ValidationException = FluentValidation.ValidationException;

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

        public async Task<FilmeModel> CadastrarFilme(FilmeCriarDto dto)
        {
            var validator = new FilmeCriarValidator();
            var result = validator.Validate(dto);

            if (!result.IsValid)
            {
                var erros = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(erros);
            }

            var filme = new FilmeModel()
            {
                Titulo = dto.Titulo,
                Sinopse = dto.Sinopse,
                Diretor = dto.Diretor,
                DataLancamento = dto.DataLancamento,
                Genero = dto.Genero,
                NotaMedia = 0,
            };

            var response = await _repository.Create(filme);
            return response;
        }

        public async Task<FilmeModel> EditarFilme(FilmeEditarDto dto)
        {
            var validator = new FilmeEditarValidator();
            var result = validator.Validate(dto);

            if (!result.IsValid)
            {
                var erros = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(erros);
            }

            var filme = await _repository.GetById(dto.Id);

            if (filme == null) throw new Exception("Filme não encontrado");

            AtualizarCampoSeMudou(filme.Titulo, dto.Titulo, novoValor => filme.Titulo = novoValor);
            AtualizarCampoSeMudou(filme.Genero, dto.Genero, novoValor => filme.Genero = novoValor);
            AtualizarCampoSeMudou(filme.Diretor, dto.Diretor, novoValor => filme.Diretor = novoValor);
            AtualizarCampoSeMudou(filme.Sinopse, dto.Sinopse, novoValor => filme.Sinopse = novoValor);

            if (dto.DataLancamento.HasValue && dto.DataLancamento != filme.DataLancamento) filme.DataLancamento = dto.DataLancamento.Value; 

            var response = await _repository.Update(filme);
            return response;
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

        private void AtualizarCampoSeMudou<T>(T campoAtual, T novoValor, Action<T> atualizarCampo)
        {
            if (novoValor != null && !Equals(campoAtual, novoValor) && !Equals(novoValor, "string"))
            {
                atualizarCampo(novoValor);
            }
        }
    }
}
