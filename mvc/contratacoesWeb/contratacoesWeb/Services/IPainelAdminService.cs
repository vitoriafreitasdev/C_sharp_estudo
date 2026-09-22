using contratacoesWeb.Data;
using contratacoesWeb.Dtos;
using contratacoesWeb.Models;
namespace contratacoesWeb.Services
{
    public interface IPainelAdminService
    {
        public Task<RetornoObjeto> LogarRecrutador(Login dados);
        public bool UsuarioEstaLogado();
        public Task<RetornoObjeto> AdicionarVaga(Vagas vaga);
        public Task<List<Vagas>> VisualizarVagas();
        public Task<Vagas> VisualizarVagaPorId(string id);
        public Task<List<Candidatos>> VisualizarCandidatos();
        public Task<RetornoObjeto> CriarRole();
        public Task<RetornoObjeto> AdicionarRecrutador(Recrutadores recrutador);

    }
}


//Funcionalidades para adicionar depois
//public Task<Vagas> RemoverVaga(string id);
//public Task<Vagas> EditarVaga(string id, Vagas vaga);
//public Task<Candidatos> VisualizarPerfilCandidato(string id, string? filtro = null);