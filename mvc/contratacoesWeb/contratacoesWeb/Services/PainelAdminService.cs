
//Painel Service
using contratacoesWeb.Data;
using contratacoesWeb.Dtos;
using contratacoesWeb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Xml.Linq;

namespace contratacoesWeb.Services
{
    public class PainelAdminService : IPainelAdminService
    {

        private UserManager<AplicacaoUser> userManager;
        private RoleManager<Roles> roleManager;
        private SignInManager<AplicacaoUser> signInManager;
        private readonly IMongoCollection<Recrutadores> _recrutadorCollection;
        private readonly IMongoCollection<Candidatos> _candidatoCollection;
        private readonly IMongoCollection<Vagas> _vagaCollection;

        public PainelAdminService(UserManager<AplicacaoUser> userManager, RoleManager<Roles> roleManager, SignInManager<AplicacaoUser> signInManager, BancoDeDados bancoDeDados)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            _recrutadorCollection = bancoDeDados.RecrutadoresCollection;
            _candidatoCollection = bancoDeDados.CandidatosCollection;
            _vagaCollection = bancoDeDados.VagasCollection;
        }

        // Login, interação com as vagas (Adição, Edição, Remoção) e outras ações.
        public async Task<RetornoObjeto> LogarRecrutador(Login dados)
        {
            AplicacaoUser? usuario = await userManager.FindByEmailAsync(dados.email);
            
            if (usuario != null && dados.senha != null)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(usuario, dados.senha, false, false);
                if (result.Succeeded)
                {
                    return new RetornoObjeto
                    {
                        mensagem = "Recrutador logado com sucesso",
                        sucesso = true
                    };
                }
            }

            return new RetornoObjeto
            {
                mensagem = "Falha ao fazer o login usuário não encontrado. Possivelmente o email está incorreto.",
                sucesso = false
            };

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
        public async Task<RetornoObjeto> CriarRole()
        {
            IdentityResult result = await roleManager.CreateAsync(new Roles() { Name = "Candidato" });
            IdentityResult result2 = await roleManager.CreateAsync(new Roles() { Name = "Recrutador" });

            if (result.Succeeded && result2.Succeeded)
                return new RetornoObjeto
                {
                    mensagem = "Roles criadas com sucesso",
                    sucesso = true
                };
            else
            {
                return new RetornoObjeto
                {
                    mensagem = "Falhas: " + string.Join(", ", result.Errors.Select(e => e.Description)) + 
                    "|| " + string.Join(", ", result2.Errors.Select(e => e.Description)),
                    sucesso = false
                };
            }
        }
        public async Task<RetornoObjeto> AdicionarRecrutador(Recrutadores recrutador)
        {
            try
            {
                AplicacaoUser appUser = new AplicacaoUser
                {
                    UserName = recrutador.nome,
                    Email = recrutador.email
                };
                IdentityResult result = await userManager.CreateAsync(appUser, recrutador.senha);

                await userManager.AddToRoleAsync(appUser, "Recrutador");

                if (!result.Succeeded)
                {
                    return new RetornoObjeto
                    {
                        mensagem = "Falha ao criar recrutador: " + string.Join(", ", result.Errors.Select(e => e.Description)),
                        sucesso = false
                    };
                }

                var senhaCripto = new SenhaHash().CriptografarRecrutadorSenha(recrutador);
                recrutador.senha = senhaCripto;
                await _recrutadorCollection.InsertOneAsync(recrutador);

                return new RetornoObjeto
                {
                    mensagem = "Recrutador adicionado com sucesso",
                    sucesso = true
                };
            }
            catch (Exception err)
            {
                throw new Exception("Erro ao adicionar recrutador: " + err.Message);
            }
        }

        public Task<bool> LogarRecrutador(Recrutadores recrutador)
        {
            throw new NotImplementedException();
        }
    }
}
