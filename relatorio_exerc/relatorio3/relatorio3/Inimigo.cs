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

        public int PontosDeRecompensa { get; private set; }

        public bool EstaVivo { get { return Vida > 0 ? true : false; } }

        public Inimigo(string nome, int vida_inicial, int forca, int pontosDeRecompensa)
        {
            Nome = nome;
            Vida = vida_inicial;
            Forca = forca;
            PontosDeRecompensa = pontosDeRecompensa;
        }

        public string Atacar(Jogador alvo)
        {
            //Ataque impedido, caso o jogador estiver sem vida ou o inimigo
            if (Vida <= 0) return "\nAtaque do inimigo impedido, vida está zerada.";
            if (alvo.Vida <= 0) return "\nAtaque impedido, alvo sem vida.";
            //Dano no alvo
            alvo.ReceberDano(Forca);
            return $"\nAtaque do {Nome} realizado.";

        }
        public string ReceberDano(int dano)
        {
            Vida -= dano;
            //Se a vida ficar negativa, será mudada para zero
            if (Vida < 0) Vida = 0;
            Console.WriteLine($"\nVida atual {Nome}: {Vida} \n");
            return "Dano sofrido.";
        }
        
    }
}
