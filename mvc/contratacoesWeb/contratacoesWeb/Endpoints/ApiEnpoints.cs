using contratacoesWeb.Data;
using contratacoesWeb.Dtos;
using contratacoesWeb.Models;
using contratacoesWeb.Services;
using Microsoft.AspNetCore.Http.HttpResults;
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

            api.MapGet("/", async (AplicacaoDbContext bd) =>
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

            }).WithName("PegarTodasVagas");

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
            }).WithName("PegarVaga");

            api.MapPost("/candidatos/registrar", async (AplicacaoDbContext db, CandidatoCadastro candidatoDados) =>
            {
                try
                {
                    Candidatos? candidatoExiste = await db.Candidatos.FirstOrDefaultAsync(c => c.email == candidatoDados.email);
                    if(candidatoExiste != null)
                    {
                        return Results.BadRequest("Candidato já registrado");
                    }

                    Candidatos candidato = new Candidatos
                    {
                        id = ObjectId.GenerateNewId(),
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
            }).WithName("CadastrarCandidato");

            api.MapGet("/candidatos/{id}", async (AplicacaoDbContext db, ObjectId id) =>
            {
                Candidatos? candidato = await db.Candidatos.FirstOrDefaultAsync(c => c.id == id);
                if(candidato != null)
                {
                    return Results.Ok(candidato);
                }
                return Results.BadRequest("Não encontrado");
            }).WithName("BuscarCandidato");

            app.MapPut("/vagas/{id}/adicionarcandidato", async(AplicacaoDbContext db, ObjectId id, ObjectId candidatoId) =>
            {
                try
                {
                    Candidatos? candidato = await db.Candidatos.FirstOrDefaultAsync(c => c.id == candidatoId);
                    Vagas? vaga = await db.Vagas.FirstOrDefaultAsync(c => c.id == id);

                    if (vaga == null || candidato == null)
                    {
                        return Results.BadRequest("Vaga ou candidato não encontrado.");
                    }

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

            }).WithName("AdicionandoCandidatoNaVaga");
        }
    }
}
