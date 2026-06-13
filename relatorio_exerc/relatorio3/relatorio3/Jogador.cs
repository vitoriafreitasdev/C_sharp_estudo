using System;
using System.Collections.Generic;
using System.Text;
//Jogador.cs
namespace relatorio3
{
    public class Jogador
    {
        public string Nome { get; set; }
        public int Vida { get; private set; }

        public int Forca { get; set; }

        public int Pontos { get; private set; }
        public bool EstaVivo { get { return Vida > 0 ? true : false; } }
        public Jogador(string nome, int vida_inicial, int forca)
        {
            Nome = nome;
            Vida = vida_inicial;
            Forca = forca;
            Pontos = 0;
        }

        public string Atacar(Inimigo alvo)
        {
            if (Vida <= 0) return "\nAtaque do jogador impedido, vida está zerada.";
            if (alvo.Vida <= 0) return "\nAtaque impedido, inimigo sem vida.";
            alvo.ReceberDano(Forca);
            return $"\nAtaque do {Nome} realizado.";
            
        }
        public string ReceberDano(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
            Console.WriteLine($"\nVida do Jogador {Nome}: {Vida} \n");
            GanharPontos(10);
            return "Dano sofrido.";
        }
        public void GanharPontos(int pontos)
        {
            Pontos += pontos;
            Console.WriteLine($"\n{Nome}: {Pontos}");
        }
    }
}
