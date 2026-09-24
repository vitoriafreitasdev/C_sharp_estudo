
//Painel Service
using contratacoesWeb.Data;
using contratacoesWeb.Dtos;
using contratacoesWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
namespace contratacoesWeb.Services
{
    public class PainelAdminService : IPainelAdminService
    {

        private UserManager<AplicacaoUser> userManager;
        private RoleManager<Roles> roleManager;
        private SignInManager<AplicacaoUser> signInManager;

        private readonly IHttpContextAccessor httpContextAccessor;

        private readonly AplicacaoDbContext _context;

        public PainelAdminService(UserManager<AplicacaoUser> userManager, RoleManager<Roles> roleManager, 
                                SignInManager<AplicacaoUser> signInManager, IHttpContextAccessor httpContextAccessor,
                                AplicacaoDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        // Login, interação com as vagas (Adição, Edição, Remoção) e outras ações.
        public async Task<RetornoObjeto> LogarRecrutador(Login dados)
        {
            AplicacaoUser? usuario = await userManager.FindByEmailAsync(dados.email);
            
            if (usuario != null && dados.senha != null)
            {
                SignInResult result = await signInManager.PasswordSignInAsync(usuario, dados.senha, false, false);
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
        public bool UsuarioEstaLogado()
        {
            var context = httpContextAccessor.HttpContext;
            var logado = context?.User.Identity?.IsAuthenticated;
            
            if (logado == true) return true;
           
            return false;
        }
        public async Task<RetornoObjeto> AdicionarVaga(Vagas vaga){
            try
            {
                await _context.Vagas.AddAsync(vaga);
                await _context.SaveChangesAsync();

                return new RetornoObjeto
                {
                    mensagem = "Adicionado com sucesso.",
                    sucesso = true
                };
            }
            catch (Exception err)
            {
                return new RetornoObjeto
                {
                    mensagem = "Erro: " + err,
                    sucesso = false
                }
                ;
            }
        }
        public async Task<List<Vagas>> VisualizarVagas()
        {
            try
            {
                List<Vagas> vagas = await _context.Vagas.ToListAsync();
                return vagas;
            }
            catch(Exception err)
            {
                throw new Exception("Erro: " + err);
            }

        }

        public async Task<Vagas?> VisualizarVagaPorId(ObjectId id)
        {
            Vagas? vaga = await _context.Vagas.FirstOrDefaultAsync(c => c.id == id);
            return vaga;
        }
        public Task<List<Candidatos>> VisualizarCandidatos(){
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
                Recrutadores? recrutadorExiste = await _context.Recrutadores.FirstOrDefaultAsync(r => r.email == recrutador.email);
                if (recrutadorExiste != null)
                {
                    return new RetornoObjeto
                    {
                        mensagem = "Recrutador já existe no sistema.",
                        sucesso = false
                    }; 
                }
                string nomeNormalizado = recrutador.nome.Replace(" ", "");
               
                AplicacaoUser appUser = new AplicacaoUser
                {
                    UserName = nomeNormalizado,
                    Email = recrutador.email
                };
                IdentityResult result = await userManager.CreateAsync(appUser, recrutador.senha);

                if(!result.Succeeded)
                {
                    return new RetornoObjeto
                    {
                        mensagem = "Falha ao criar recrutador: " + string.Join(", ", result.Errors.Select(e => e.Description)),
                        sucesso = false
                    };
                }
                IdentityResult result2 = await userManager.AddToRoleAsync(appUser, "Recrutador");

                if (!result2.Succeeded)
                {
                    return new RetornoObjeto
                    {
                        mensagem = "Falha ao criar recrutador: " + string.Join(", ", result.Errors.Select(e => e.Description)),
                        sucesso = false
                    };
                }

                var senhaCripto = new SenhaHash().CriptografarRecrutadorSenha(recrutador);
                recrutador.senha = senhaCripto;

                await _context.Recrutadores.AddAsync(recrutador);
                await _context.SaveChangesAsync();

                return new RetornoObjeto
                {
                    mensagem = "Recrutador adicionado com sucesso",
                    sucesso = true
                };
            }
            catch (Exception err)
            {
                throw new Exception("Erro ao tentar inserir recrutador: " + err);
            }
        }

    }
}
