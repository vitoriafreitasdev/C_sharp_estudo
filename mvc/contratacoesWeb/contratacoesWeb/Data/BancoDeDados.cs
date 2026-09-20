using contratacoesWeb.Models;
using MongoDB.Driver;

namespace contratacoesWeb.Data
{
    public class BancoDeDados 
    {
        private readonly IMongoCollection<Recrutadores> _recrutadoresCollection;
        private readonly IMongoCollection<Candidatos> _candidatosCollection;
        private readonly IMongoCollection<Vagas> _vagasCollection;

        public BancoDeDados(IMongoClient mongoClient, IConfiguration configuration)
        {
            var databaseName = configuration.GetValue<string>("MongoDbSettings:DatabaseName");

            var employeeCollectionName = configuration.GetValue<string>("MongoDbSettings:Collections:Recrutadores");
            var candidatoCollectionName = configuration.GetValue<string>("MongoDbSettings:Collections:Candidatos");
            var vagaCollectionName = configuration.GetValue<string>("MongoDbSettings:Collections:Vagas");

            var database = mongoClient.GetDatabase(databaseName);

            _recrutadoresCollection = database.GetCollection<Recrutadores>(employeeCollectionName);
            _candidatosCollection = database.GetCollection<Candidatos>(candidatoCollectionName);
            _vagasCollection = database.GetCollection<Vagas>(vagaCollectionName);
        }

        public IMongoCollection<Recrutadores> RecrutadoresCollection => _recrutadoresCollection;
        public IMongoCollection<Candidatos> CandidatosCollection => _candidatosCollection;
        public IMongoCollection<Vagas> VagasCollection => _vagasCollection;
    }

}
