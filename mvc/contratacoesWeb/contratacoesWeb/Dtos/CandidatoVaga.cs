using contratacoesWeb.Models;
using MongoDB.Bson;

namespace contratacoesWeb.Dtos
{
    public class CandidatoVaga
    {
        public ObjectId id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public Endereco endereco { get; set; }
        public int anosExperiencia { get; set; }
        public string formacaoAcademica { get; set; }
        public List<string> habilidades { get; set; }
        public string? linkedin { get; set; }
        public string? portfolio { get; set; }
    }
}
