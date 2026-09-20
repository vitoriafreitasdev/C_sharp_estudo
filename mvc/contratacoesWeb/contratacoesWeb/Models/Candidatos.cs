using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.AspNetCore.Identity;

namespace contratacoesWeb.Models
{
    public class Candidatos 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string telefone { get; set; }
        public Endereco endereco { get; set; }
        public int anosExperiencia { get; set; }
        public string formacaoAcademica { get; set; }
        public List<string> habilidades { get; set; }
        public string? linkedin { get; set; }
        public string? portfolio { get; set; }
    }
}

//(nome, email, senha, telefone, endereço, experiência profissional, formação acadêmica, habilidades, linkedin, portfolio)