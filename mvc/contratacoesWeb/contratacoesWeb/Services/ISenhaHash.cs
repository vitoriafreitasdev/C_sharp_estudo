using contratacoesWeb.Models;

namespace contratacoesWeb.Services
{
    public interface ISenhaHash
    {
        string CriptografarRecrutadorSenha(Recrutadores recrutador);
        bool VerificarRecrutadorSenha(Recrutadores recrutador, string hashedPassword);
        string CriptografarCandidatoSenha(Candidatos candidato);
        bool VerificarCandidatoSenha(Candidatos candidato, string hashedPassword);
    }
}
