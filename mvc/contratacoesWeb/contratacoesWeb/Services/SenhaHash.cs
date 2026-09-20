using contratacoesWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace contratacoesWeb.Services
{
    
    public class SenhaHash : ISenhaHash

    {
        private readonly PasswordHasher<Recrutadores> _criptRecrutador = new PasswordHasher<Recrutadores>();

        private readonly PasswordHasher<Candidatos> _criptCandidato = new PasswordHasher<Candidatos>();

        public string CriptografarRecrutadorSenha(Recrutadores recrutador)
        {
            return _criptRecrutador.HashPassword(recrutador, recrutador.senha);
        }
        public bool VerificarRecrutadorSenha(Recrutadores recrutador, string textoSenha)
        {
            var result = _criptRecrutador.VerifyHashedPassword(recrutador, recrutador.senha, textoSenha);
            return result == PasswordVerificationResult.Success;
        }

        public string CriptografarCandidatoSenha(Candidatos candidato)
        {
            return _criptCandidato.HashPassword(candidato, candidato.senha);
        }
        public bool VerificarCandidatoSenha(Candidatos candidato, string hashedPassword)
        {
            var result = _criptCandidato.VerifyHashedPassword(candidato, hashedPassword, candidato.senha);
            return result == PasswordVerificationResult.Success;
        }
    }


}
