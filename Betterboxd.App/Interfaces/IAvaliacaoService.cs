using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.App.Dtos;
using Betterboxd.Core.Entities;

namespace Betterboxd.App.Interfaces
{
    public interface IAvaliacaoService
    {
        Task<List<AvaliacaoModel>> ListarTodos();
        Task<AvaliacaoModel>BuscarPorId(int id);
        Task<List<AvaliacaoModel>> ListarPorIdFilme(int idFilme);
        Task<List<AvaliacaoModel>> ListarPorIdUser(int idUser);
        Task<AvaliacaoModel> CadastrarAvaliacao(AvaliacaoCriarDto dto);
        Task<AvaliacaoModel> EditarAvaliacao(AvaliacaoEditarDto dto, int id);
        Task<AvaliacaoModel> RemoverAvaliacao(int id);
    }
}
