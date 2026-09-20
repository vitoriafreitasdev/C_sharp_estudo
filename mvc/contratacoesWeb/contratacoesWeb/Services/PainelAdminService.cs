
//Painel Service
using contratacoesWeb.Data;
using contratacoesWeb.Dtos;
using contratacoesWeb.Models;
using MongoDB.Driver;

namespace contratacoesWeb.Services
{
    public class PainelAdminService : IPainelAdminService
    {
        private readonly IMongoCollection<Recrutadores> _recrutadorCollection;
        private readonly IMongoCollection<Candidatos> _candidatoCollection;
        private readonly IMongoCollection<Vagas> _vagaCollection;

    
        public PainelAdminService( BancoDeDados bancoDeDados)
        {
            _recrutadorCollection = bancoDeDados.RecrutadoresCollection;
            _candidatoCollection = bancoDeDados.CandidatosCollection;
            _vagaCollection = bancoDeDados.VagasCollection;
        }
        public async Task<bool> LogarRecrutador(Login dados)
        {
            Recrutadores recrutador = await _recrutadorCollection.Find(r => r.email == dados.email).FirstOrDefaultAsync();
            var senhaCorreta = new SenhaHash().VerificarRecrutadorSenha(recrutador, dados.senha);
            if (!senhaCorreta)
            {
                throw new Exception("Senha incorreta.");
            }
            

            return false;
        }
        public Task<Vagas> AdicionarVaga(Vagas vaga){
            throw new NotImplementedException();
        }
        public Task<Vagas> EditarVaga(string id, Vagas vaga){
            throw new NotImplementedException();
        }
        public Task<Vagas> RemoverVaga(string id){
            throw new NotImplementedException();
        }
        public Task<List<Candidatos>> VisualizarCandidatos(){
            throw new NotImplementedException();
        }
        public Task<Candidatos> VisualizarPerfilCandidato(string id, string? filtro = null){
            throw new NotImplementedException();
        }
        public async Task<bool> AdicionarRecrutador(Recrutadores recrutador)
        {
            try
            {
                var senhaCripto = new SenhaHash().CriptografarRecrutadorSenha(recrutador);
                recrutador.senha = senhaCripto;
                await _recrutadorCollection.InsertOneAsync(recrutador);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar recrutador: {ex.Message}");
            }
        }

        public Task<bool> LogarRecrutador(Recrutadores recrutador)
        {
            throw new NotImplementedException();
        }
    }
}
