using System;
using System.Collections.Generic;
using System.Text;


namespace relatorio3
{
    public class Game
    {
        public void Execucar()
        {
            Jogador jogador1 = new Jogador("Kratos", 150, 30);
            Inimigo inimigo1 = new Inimigo("Baldur", 110, 10, 15);
            Inimigo inimigo2 = new Inimigo("Thor", 120, 12, 12);
            Inimigo inimigo3 = new Inimigo("Odin", 130, 14, 12);

            // Lista de inimigos que o jogador enfrentará
            List<Inimigo> inimigos = new List<Inimigo> { inimigo1, inimigo2, inimigo3 };

            Console.WriteLine($"\nJogador Estados Iniciais: ");
            Console.WriteLine($"\nNome: {jogador1.Nome} - Vida: {jogador1.Vida}");

            Console.WriteLine($"\nInimigo 1 Estados Iniciais: ");
            Console.WriteLine($"\nNome: {inimigo1.Nome} - Vida: {inimigo1.Vida}");

            Console.WriteLine($"\nInimigo 2 Estados Iniciais: ");
            Console.WriteLine($"\nNome: {inimigo2.Nome} - Vida: {inimigo2.Vida}");

            // Para cada inimigo ocorrerá uma batalha, se o jogador estiver vivo
            inimigos.ForEach(x =>
            {
                if (jogador1.EstaVivo == true) Batalhar(jogador1, x);
            }
            );

            Console.WriteLine("\nBatalha encerrada.");

            Console.WriteLine($"\nStatus do Jogador Finais: ");
            Console.WriteLine($"\nVida: {jogador1.Vida} - Pontos {jogador1.Pontos}");

        }
        public void Batalhar(Jogador jogador, Inimigo inimigo)
        {
            Console.WriteLine("\n Batalha ");
            Console.WriteLine($" {jogador.Nome} vs {inimigo.Nome}");
            Console.WriteLine($"\nStatus antes da batalha");
            Console.WriteLine($"Jogador: {jogador.Nome} | Vida: {jogador.Vida} | Ataque: {jogador.Forca}");
            Console.WriteLine($"Inimigo: {inimigo.Nome} | Vida: {inimigo.Vida} | Ataque: {inimigo.Forca}");

            int turno = 1;
            // Loop até alguns deles morrer.
            while (jogador.EstaVivo == true && inimigo.EstaVivo == true)
            {
                Console.WriteLine($"\n  Turno: {turno}  \n");
                string ataqueJogador = jogador.Atacar(inimigo);
                string ataqueInimigo = inimigo.Atacar(jogador);
                Console.WriteLine("Ataque Jogador: " + ataqueJogador);
                Console.WriteLine("Ataque Inimigo: " + ataqueInimigo);

                Console.WriteLine("\n Aperte ENTER para continuar n");
                string key = Console.ReadKey().Key.ToString().ToLower();
                if (key != "enter") break;
                turno += 1;
            }

            //Se o jogador estiver vivo e o inimigo não ele foi o vencedor.
            if(jogador.EstaVivo == true && inimigo.EstaVivo == false)
            {
                Console.WriteLine($"{jogador.Nome} vencedor!");
                jogador.GanharPontos(10);
            }
            else
            {
                Console.WriteLine("Fim de jogo, vida do jogador zerada.");
            }
        }
    }
}
