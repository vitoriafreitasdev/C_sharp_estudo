using System;
using System.Collections.Generic;
using System.Text;
//Inimigo.cs
namespace relatorio3
{
    public class Inimigo
    {
        public string Nome { get; set; }
        public int Vida { get; private set; }

        public int Forca { get; set; }

        public int Pontos { get; private set; }

        public bool EstaVivo { get { return Vida > 0 ? true : false; } }

        public Inimigo(string nome, int vida, int forca, int pontosRec)
        {
            Nome = nome;
            Vida = vida;
            Forca = forca;
            Pontos = pontosRec;
        }

        public string Atacar(Jogador alvo)
        {
            //Caso vida do inimigo ou do jogador seja zero, o ataque é impedido
            if (Vida <= 0) return "\nAtaque do inimigo impedido.";
            if (alvo.Vida <= 0) return "\nAtaque impedido.";
            //Dano no alvo
            alvo.ReceberDano(Forca);
            return $"\nAtaque do {Nome} realizado.";

        }
        public string ReceberDano(int dano)
        {
            Vida -= dano;
            //Caso a vida ficar negativa, será mudada para zero
            if (Vida < 0) Vida = 0;
            Console.WriteLine($"\nNome: {Nome}, Vida: {Vida} \n");
            return "Dano recebido.";
        }
        
    }
}
