using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace contratacoesWeb.Models
{
    public class Vagas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public List<string> requisitos { get; set; }
        public Endereco localizacao { get; set; }
        public string modelo { get; set; }
        public string tipo { get; set; }
        public List<Candidatos>? candidatos { get; set; } = null;
    }
    public enum Modelo
    {
        Presencial,
        Remoto,
        Hibrido
    }
    public enum TipoVaga
    {
        Estagio,
        Trainee,
        Junior,
        Pleno,
        Senior
    }
}
