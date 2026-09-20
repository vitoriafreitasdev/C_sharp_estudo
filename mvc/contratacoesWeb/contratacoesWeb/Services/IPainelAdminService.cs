using contratacoesWeb.Data;
using contratacoesWeb.Dtos;
using contratacoesWeb.Models;
namespace contratacoesWeb.Services
{
    public interface IPainelAdminService
    {
        public Task<RetornoObjeto> LogarRecrutador(Login dados);
        public Task<Vagas> AdicionarVaga(Vagas vaga);
        public Task<Vagas> EditarVaga(string id, Vagas vaga);
        public Task<Vagas> RemoverVaga(string id);
        public Task<List<Candidatos>> VisualizarCandidatos();
        public Task<Candidatos> VisualizarPerfilCandidato(string id, string? filtro = null);
        public Task<RetornoObjeto> CriarRole();
        public Task<RetornoObjeto> AdicionarRecrutador(Recrutadores recrutador);

    }
}
