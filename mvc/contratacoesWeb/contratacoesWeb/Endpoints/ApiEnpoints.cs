using contratacoesWeb.Data;
using contratacoesWeb.Dtos;
using contratacoesWeb.Models;
using contratacoesWeb.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace contratacoesWeb.Endpoints
{
    public static class ApiEnpoints
    {

        public static void MapApiEndpoints(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("/api");

            api.MapGet("/vagas", async (AplicacaoDbContext bd) =>
            {
                try
                {
                    List<Vagas> vagas = await bd.Vagas.ToListAsync();
                    return Results.Ok(vagas);
                }
                catch (Exception err)
                {
                    return Results.BadRequest(err);
                }

            });

            api.MapGet("/vagas/{id}", async (AplicacaoDbContext bd, ObjectId id) =>
            {
                try
                {
                    Vagas? vaga = await bd.Vagas.FirstOrDefaultAsync(c => c.id == id);
                    if (vaga != null)
                    {
                        return Results.Ok(vaga);
                    }
                    return Results.BadRequest("Não encontrado.");
                }
                catch (Exception err)
                {
                    return Results.BadRequest(err);
                }
            });

            api.MapPost("/candidatos/registrar", async (AplicacaoDbContext db, 
                UserManager<AplicacaoUser> userManager, CandidatoCadastro candidatoDados) =>
            {
                try
                {
                    Candidatos? candidatoExiste = await db.Candidatos.FirstOrDefaultAsync(c => c.email == candidatoDados.email);
                    if(candidatoExiste != null) return Results.BadRequest("Candidato já registrado");
                   
                    Candidatos candidato = new Candidatos
                    {
                        nome = candidatoDados.nome,
                        email = candidatoDados.email,
                        senha = candidatoDados.senha,
                        telefone = candidatoDados.telefone,
                        endereco = candidatoDados.endereco,
                        anosExperiencia = candidatoDados.anosExperiencia,
                        formacaoAcademica = candidatoDados.formacaoAcademica,
                        habilidades = candidatoDados.habilidades,
                        linkedin = candidatoDados.linkedin,
                        portfolio = candidatoDados.portfolio
                    };

                    //adicionando no identity
                    string nomeNormalizado = candidato.nome.Replace(" ", "");
                    AplicacaoUser appUser = new AplicacaoUser
                    {
                        UserName = nomeNormalizado,
                        Email = candidato.email
                    };

                    IdentityResult result = await userManager.CreateAsync(appUser, candidato.senha);
                    if (!result.Succeeded) return Results.BadRequest("Erro: " + 
                        string.Join(", ", result.Errors.Select(e => e.Description)));

                    IdentityResult result2 = await userManager.AddToRoleAsync(appUser, "Candidato");
                    if (!result2.Succeeded) return Results.BadRequest("Erro: " +
                        string.Join(", ", result.Errors.Select(e => e.Description)));

                    var senhaCripto = new SenhaHash().CriptografarCandidatoSenha(candidato);
                    candidato.senha = senhaCripto;

                    await db.Candidatos.AddAsync(candidato);
                    await db.SaveChangesAsync();

                    return Results.Ok("Adicionado com sucesso");
                }
                catch (Exception err)
                {
                    return Results.BadRequest(err);
                }
            });

            api.MapPost("/candidatos/logar", async (AplicacaoDbContext db, UserManager<AplicacaoUser> userManager,
                SignInManager<AplicacaoUser> signInManager, [FromBody] LoginCandidato login) =>
            {
                try
                {
                    if (login.senha == null) return Results.BadRequest("Coloque senha.");

                    AplicacaoUser? usuario = await userManager.FindByEmailAsync(login.email);
                    Candidatos? candidato = await db.Candidatos.FirstOrDefaultAsync(c => c.email == login.email);

                    if (usuario == null) return Results.BadRequest("Usuário não encontratado");

                    var result = await signInManager.PasswordSignInAsync(usuario, login.senha, false, false);
                    if (!result.Succeeded) return Results.BadRequest("Erro ao logar");

                    return Results.Ok(candidato);
                }
                catch (Exception err)
                {
                    return Results.BadRequest(err);
                }
            });

            api.MapGet("/candidatos/{id}", async (AplicacaoDbContext db, ObjectId id) =>
            {
                Candidatos? candidato = await db.Candidatos.FirstOrDefaultAsync(c => c.id == id);
                if(candidato != null)
                {
                    return Results.Ok(candidato);
                }
                return Results.BadRequest("Não encontrado");
            });
            
            api.MapPut("/vagas/{id}/adicionarcandidato", async (AplicacaoDbContext db, IHttpContextAccessor httpContextAccessor,
                ObjectId id, ObjectId candidatoId) =>
            {
                try
                {
                    var context = httpContextAccessor.HttpContext;
                    var logado = context?.User.Identity?.IsAuthenticated;

                    if (logado != true) return Results.BadRequest("Usuário não logado");

                    Candidatos? candidato = await db.Candidatos.FirstOrDefaultAsync(c => c.id == candidatoId);
                    Vagas? vaga = await db.Vagas.FirstOrDefaultAsync(c => c.id == id);

                    if (vaga == null || candidato == null) return Results.BadRequest("Vaga ou candidato não encontrado.");

                    CandidatoVaga candidatoAdd = new CandidatoVaga()
                    {
                        id = candidato.id,
                        nome = candidato.nome,
                        email = candidato.email,
                        telefone = candidato.telefone,
                        endereco = candidato.endereco,
                        anosExperiencia = candidato.anosExperiencia,
                        formacaoAcademica = candidato.formacaoAcademica,
                        habilidades = candidato.habilidades,
                        linkedin = candidato.linkedin,
                        portfolio = candidato.portfolio
                    };

                    vaga.candidatos.Add(candidatoAdd);
                    await db.SaveChangesAsync();
                    return Results.Ok(vaga);
                }
                catch (Exception err)
                {
                    return Results.BadRequest(err);
                }

            });

            api.MapDelete("deletarCandidato/{id}", async (AplicacaoDbContext db, UserManager<AplicacaoUser> userManager, ObjectId id) =>
            {
                try
                {
                    Candidatos? candidato = await db.Candidatos.FirstOrDefaultAsync(c => c.id == id);

                    if (candidato == null) return Results.BadRequest("Usuário não encontrado.");

                    AplicacaoUser? usuario = await userManager.FindByEmailAsync(candidato.email);

                    if (usuario == null) return Results.BadRequest("Usuário não encontrado.");

                    IdentityResult result = await userManager.DeleteAsync(usuario);

                    if (!result.Succeeded) return Results.BadRequest("Houve um erro ao tentar deletar a conta. Erro: " +
                            string.Join(", ", result.Errors.Select(e => e.Description)));

                    db.Candidatos.Remove(candidato);
                    await db.SaveChangesAsync();

                    return Results.Ok("Conta deletada.");
                }
                catch (Exception err)
                {
                    return Results.BadRequest(err);
                }

            });
        }
    }
}
