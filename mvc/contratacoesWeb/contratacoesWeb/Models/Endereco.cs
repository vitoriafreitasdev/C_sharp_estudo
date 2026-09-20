using System.ComponentModel.DataAnnotations;

namespace contratacoesWeb.Models
{
    public class Endereco
    {
        public string estado { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string rua { get; set; }
        public string cep { get; set; }
    }
}
