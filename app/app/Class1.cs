using System;
using System.Collections.Generic;
using System.Linq;
namespace TinderApp
{
    public class Perfil
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<string> Interesses { get; set; }
        public string Localizacao { get; set; }
        private readonly List<Perfil> perfisCurtidos = new List<Perfil>();
        private readonly List<Perfil> matches = new List<Perfil>();
        public Perfil(string nome, int idade, List<string> interesses, string
       localizacao)
        {
            Nome = nome;
            Idade = idade;
            Interesses = interesses ?? new List<string>();
            Localizacao = localizacao;
        }
        /// <summary>
        /// Registra uma curtida no perfil “outro” e retorna true
        /// se houver curtida mútua (match).
        /// </summary>
        public bool Curtir(Perfil outro)
        {
            if (outro == null)
                return false;
            // Adiciona o outro perfil à lista de curtidos, se ainda não estiver lá
        if (!perfisCurtidos.Contains(outro))
            {
                perfisCurtidos.Add(outro);
            }
            // Verifica se o outro perfil já havia curtido este
            if (outro.perfisCurtidos.Contains(this))
            {
                // Garante que o match seja registrado nos dois perfis
                if (!matches.Contains(outro))
                {
                    matches.Add(outro);
                }
                if (!outro.matches.Contains(this))
                {
                    outro.matches.Add(this);
                }
                return true; // houve match
            }
            return false; // ainda não houve match mútuo
        }
        /// <summary>
        /// Indica se este perfil tem match com o perfil “outro”.
        /// </summary>
        public bool TemMatchCom(Perfil outro)
        {
            if (outro == null)
                return false;
            return matches.Contains(outro);
        }
        /// <summary>
        /// Critério simples de compatibilidade: pelo menos um interesse
        /// em comum e mesma localização (comparação sem diferenciar maiúsculas/minúsculas).
 /// </summary>
 public bool EhCompatívelCom(Perfil outro)
        {
            if (outro == null)
                return false;
            bool interessesComuns =
             Interesses.Intersect(outro.Interesses).Any();
            bool mesmaLocal =
            string.Equals(Localizacao, outro.Localizacao,
            StringComparison.OrdinalIgnoreCase);
            return interessesComuns && mesmaLocal;
        }
    }
}