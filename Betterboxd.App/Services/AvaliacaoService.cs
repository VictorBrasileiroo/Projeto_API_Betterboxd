using Betterboxd.App.Dtos;
using Betterboxd.App.Interfaces;
using Betterboxd.App.Validations;
using Betterboxd.Core.Entities;
using Betterboxd.Core.Interfaces;
using FluentValidation;

namespace Betterboxd.App.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _repository;
        private readonly IFilmeRepository _repositoryFilm;
        private readonly IUserRepository _repositoryUser;
        private readonly IFilmeServices _serviceFilm;
        public AvaliacaoService(IAvaliacaoRepository repository, IFilmeRepository repositoryFilm, IUserRepository userRepository, IFilmeServices serviceFilm)
        {
            _repository = repository;
            _repositoryFilm = repositoryFilm;
            _repositoryUser = userRepository;
            _serviceFilm = serviceFilm;
        }

        public async Task<AvaliacaoModel> BuscarPorId(int id)
        {
            var response = await _repository.GetById(id);
            return response;
        }

        public async Task<AvaliacaoModel> CadastrarAvaliacao(AvaliacaoCriarDto dto)
        {
            var validator = new AvaliacaoCriarValidator();
            var result = validator.Validate(dto);

            if (!result.IsValid)
            {
                var erros = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(erros);
            }

            var userValid = await _repositoryUser.GetById(dto.IdUser);
            var filmValid = await _repositoryFilm.GetById(dto.IdFilme);

            if (userValid == null) throw new Exception("Usuário não encontrado");
            if (filmValid == null) throw new Exception("Filme não encontrado");

            var avaliacao = new AvaliacaoModel()
            {
                IdFilme = dto.IdFilme,
                IdUser = dto.IdUser,
                Comentario = dto.Comentario,
                Nota = dto.Nota,
                DataAvaliacao = dto.DataAvaliacao
            };

            var response = await _repository.Create(avaliacao);
            await _serviceFilm.AtualizarNotaMediaFilme(dto.IdFilme);
            return response;
        }

        public async Task<AvaliacaoModel> EditarAvaliacao(AvaliacaoEditarDto dto, int id)
        {
            var validator = new AvaliacaoEditarValidator();
            var result = validator.Validate(dto);

            if (!result.IsValid)
            {
                var erros = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(erros);
            }

            var avaliacao = await _repository.GetById(id);
            if (avaliacao == null) throw new Exception("Avaliação não encontrada");

            AtualizarCampoSeMudou(avaliacao.Comentario, dto.Comentario, novoValor => avaliacao.Comentario = novoValor);
            AtualizarCampoSeMudou(avaliacao.Nota, dto.Nota, novoValor => avaliacao.Nota = novoValor);
            if (dto.DataAvaliacao != avaliacao.DataAvaliacao && dto.DataAvaliacao != default) avaliacao.DataAvaliacao = dto.DataAvaliacao;

            var response = await _repository.Update(avaliacao);
            await _serviceFilm.AtualizarNotaMediaFilme(avaliacao.IdFilme);
            return response;
        }

        public async Task<List<AvaliacaoModel>> ListarPorIdFilme(int idFilme)
        {
            var filme = await _repositoryFilm.GetById(idFilme);

            if (filme == null) throw new KeyNotFoundException("Filme não encontrado!");

            var response = await _repository.GetAllByFilmId(idFilme);

            return response;
        }

        public async Task<List<AvaliacaoModel>> ListarPorIdUser(int idUser)
        {
            var user = await _repositoryUser.GetById(idUser);

            if (user == null) throw new KeyNotFoundException("Usuário não encontrado!");

            var response = await _repository.GetAllByUserId(idUser);

            return response;
        }

        public async Task<List<AvaliacaoModel>> ListarTodos()
        {
            var response = await _repository.GetAll();
            return response;
        }

        public async Task<AvaliacaoModel> RemoverAvaliacao(int id)
        {
            var avaliacao = await _repository.GetById(id);
            if(avaliacao == null) throw new KeyNotFoundException("Avaliação não encontrada!");
            var response = await _repository.Delete(avaliacao);
            await _serviceFilm.AtualizarNotaMediaFilme(avaliacao.IdFilme);
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
