using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace contratacoesWeb.Models
{
    public class Vagas
    {
        public ObjectId id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public List<string> requisitos { get; set; }
        public Endereco localizacao { get; set; }
        public string modelo { get; set; }
        public string tipo { get; set; }
        public List<CandidatoVaga> candidatos { get; set; } = new List<CandidatoVaga>();
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
