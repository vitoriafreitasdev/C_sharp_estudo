using contratacoesWeb.Data;
using contratacoesWeb.Models;
using MongoDB.Driver;

namespace contratacoesWeb.Endpoints
{
    public static class ApiEnpoints
    {
        public static void MapApiEndpoints(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("/api/Vagas");

            api.MapGet("/", async (BancoDeDados bd) =>
            {
                try
                {
                    List<Vagas> vagas = await bd.VagasCollection.Find(Builders<Vagas>.Filter.Empty)
                                                                    .ToListAsync();
                    return Results.Ok(vagas);
                }
                catch (Exception err)
                {
                    return Results.BadRequest(err);
                }

            }).WithName("PegarTodasVagas");

            api.MapGet("/vagas/{id}", async (BancoDeDados bd, string id) =>
            {
                try
                {
                    Vagas vaga = await bd.VagasCollection.Find(Builders<Vagas>.Filter
                                                        .Eq((p) => p.id, id))
                                                            .FirstOrDefaultAsync();
                    return Results.Ok(vaga);
                }
                catch (Exception err)
                {
                    return Results.BadRequest(err);
                }
            }).WithName("PegarVaga");
        }
    }
}
