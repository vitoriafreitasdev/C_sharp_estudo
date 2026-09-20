namespace contratacoesWeb.Data
{
    public class Collections
    {
        public string Recrutadores { get; set; }
        public string Candidatos { get; set; }
        public string Vagas { get; set; }
    }

    public class Configuracoes
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public Collections Collections { get; set; }
    }
}
