using System; // Importa o namespace básico da biblioteca padrão
//==============================================================
// EXEMPLO SIMPLES DE CONDICIONAIS E LAÇOS EM C#
//==============================================================
// - Cada instrução termina com ponto e vírgula (;)
// - Blocos de código são delimitados por chaves, { e }
// - Identificadores são case-sensitive: "aluno" e "Aluno" são nomes diferentes
//==============================================================
Console.WriteLine("=== Demonstração de condicionais e laços em C# ===");
Console.WriteLine();
// -------------------------------------------------------------
// 1) IDENTIFICADORES CASE-SENSITIVE
// -------------------------------------------------------------
// Aqui criamos duas variáveis com nomes quase iguais:
// "aluno" (com ‘a’ minúsculo) e "Aluno" (com ‘A’ maiúsculo).
// Em C#, isso representa dois identificadores diferentes.
int aluno = 10;
int Aluno = 20;
Console.WriteLine("Exemplo de identificadores case-sensitive:");
Console.WriteLine($"aluno = {aluno}"); // Usa a variável com ‘a’ minúsculo
Console.WriteLine($"Aluno = {Aluno}"); // Usa a variável com ‘A’ maiúsculo
Console.WriteLine();
// -------------------------------------------------------------
// 2) IF / ELSE IF / ELSE
// -------------------------------------------------------------
// Vamos usar uma variável "nota" e classificar o desempenho do aluno.
// Somente UM dos blocos será executado, de acordo com o valor de "nota".
int nota = 75; // Altere este valor (de 0 a 100) e veja o resultado mudar
Console.WriteLine("Exemplo de if / else if / else com a variável 'nota'.");
Console.WriteLine($"Nota = {nota}");
if (nota < 50)
{
    // Este bloco executa se a condição (nota < 50) for verdadeira
    Console.WriteLine("Resultado: abaixo da média.");
}
else if (nota < 70)
{
    // Este bloco é testado se o anterior NÃO é verdadeiro
    Console.WriteLine("Resultado: na média.");
}
else if (nota < 90)
{
    Console.WriteLine("Resultado: bom desempenho.");
}
else
{
    // Este bloco é o "caso padrão", quando nenhuma condição anterior é verdadeira
    Console.WriteLine("Resultado: excelente desempenho!");
}
Console.WriteLine();
// -------------------------------------------------------------
// 3) SWITCH
// -------------------------------------------------------------
// Agora usamos um "switch" para reagir a um comando simples.
// Valor possível em "comando": ‘A’ (Atacar), ‘D’ (Defender), ‘F’ (Fugir).
char comando = 'A'; // Experimente mudar para ‘D’, ‘F’ ou outro caractere
Console.WriteLine("Exemplo de switch com um comando simples (A, D ou F).");
Console.WriteLine($"Comando = {comando}");
switch (comando)
{
    case 'A':
        // Se o comando for ‘A’, este bloco é executado
        Console.WriteLine("Ação escolhida: Atacar.");
        break; // Encerra o switch aqui
    case 'D':
        Console.WriteLine("Ação escolhida: Defender.");
        break;
    case 'F':
        Console.WriteLine("Ação escolhida: Fugir.");
        break;
    default:
        // Este bloco executa quando o valor de "comando" não é A, D nem F
        Console.WriteLine("Ação desconhecida.");
        break;
}
Console.WriteLine();
// -------------------------------------------------------------
// 4) LAÇO FOR
// -------------------------------------------------------------
// O laço for é útil para repetir algo um número conhecido de vezes.
// Aqui vamos contar de 1 a 5.
Console.WriteLine("Exemplo de laço for: contar de 1 até 5.");
for (int i = 1; i <= 5; i++)
{
    // Dentro das chaves está o corpo do laço.
    // A cada repetição, "i" é incrementado em 1 (i++)
    Console.WriteLine($"i vale {i}");
}
Console.WriteLine();
// -------------------------------------------------------------
// 5) LAÇO WHILE
// -------------------------------------------------------------
// O while repete ENQUANTO a condição for verdadeira.
// Aqui fazemos uma contagem regressiva simples.
Console.WriteLine("Exemplo de laço while: contagem regressiva a partir de 3.");
int contador = 3; // Valor inicial, você pode alterar
while (contador > 0)
{
    // Este bloco roda enquanto contador for maior que 0
    Console.WriteLine($"Contador = {contador}");
    // Diminui o valor de contador em 1 a cada repetição
    contador--;
}
// Quando contador chega a 0, a condição (contador > 0) fica falsa
// e o laço while termina
Console.WriteLine("Fim da contagem regressiva.");
Console.WriteLine();
Console.WriteLine("Programa encerrado. Pressione ENTER para sair.");
Console.ReadLine(); // Mantém a janela do console aberta até o usuário apertar ENTER

//

namespace MiniJogoDeBatalha
{
    // ---------------------------------------------------------
    // CLASSE Jogador
    // ---------------------------------------------------------
    class Jogador
    {
        // Propriedade que representa o nome do jogador.
        public string Nome { get; set; }

        // Propriedade que indica quanta vida o jogador tem.
        // A leitura é pública, mas só a própria classe pode alterar.
        public int Vida { get; private set; }

        // Propriedade que indica a força do ataque.
        public int Forca { get; set; }

        // Propriedade que acumula pontos ganhos durante o jogo.
        public int Pontuacao { get; private set; }

        // Propriedade somente de leitura que indica se o jogador ainda está vivo.
        public bool EstaVivo => Vida > 0;

        // Construtor da classe Jogador.
        public Jogador(string nome, int vidaInicial, int forcaInicial)
        {
            Nome = nome;
            Vida = vidaInicial;
            Forca = forcaInicial;
            Pontuacao = 0;
        }

        // Método Atacar
        public void Atacar(Inimigo alvo)
        {
            if (!EstaVivo)
            {
                Console.WriteLine($"{Nome} não pode atacar porque está sem vida.");
                return;
            }

            if (!alvo.EstaVivo)
            {
                Console.WriteLine($"{Nome} não pode atacar {alvo.Nome} porque ele já foi derrotado.");
                return;
            }

            Console.WriteLine($"{Nome} ataca {alvo.Nome} causando {Forca} de dano.");
            alvo.ReceberDano(Forca);
        }

        // Método ReceberDano
        public void ReceberDano(int dano)
        {
            Vida -= dano;

            if (Vida < 0)
            {
                Vida = 0;
            }

            Console.WriteLine($"{Nome} agora tem {Vida} de vida.");
        }

        // Método GanharPontos
        public void GanharPontos(int pontos)
        {
            Pontuacao += pontos;
            Console.WriteLine($"{Nome} ganhou {pontos} pontos. Pontuação atual: {Pontuacao}.");
        }
    }

    // ---------------------------------------------------------
    // CLASSE Inimigo
    // ---------------------------------------------------------
    class Inimigo
    {
        public string Nome { get; set; }
        public int Vida { get; private set; }
        public int Forca { get; set; }
        public int PontosDeRecompensa { get; set; }

        public bool EstaVivo => Vida > 0;

        public Inimigo(string nome, int vidaInicial, int forcaInicial, int pontosDeRecompensa)
        {
            Nome = nome;
            Vida = vidaInicial;
            Forca = forcaInicial;
            PontosDeRecompensa = pontosDeRecompensa;
        }

        public void Atacar(Jogador alvo)
        {
            if (!EstaVivo)
            {
                Console.WriteLine($"{Nome} não pode atacar porque já foi derrotado.");
                return;
            }

            if (!alvo.EstaVivo)
            {
                Console.WriteLine($"{Nome} não pode atacar {alvo.Nome} porque ele já está sem vida.");
                return;
            }

            Console.WriteLine($"{Nome} ataca {alvo.Nome} causando {Forca} de dano.");
            alvo.ReceberDano(Forca);
        }

        public void ReceberDano(int dano)
        {
            Vida -= dano;

            if (Vida < 0)
            {
                Vida = 0;
            }

            Console.WriteLine($"{Nome} agora tem {Vida} de vida.");
        }
    }

    // ---------------------------------------------------------
    // CLASSE Jogo
    // ---------------------------------------------------------
    class Jogo
    {
        public void Executar()
        {
            Console.WriteLine("=== Minijogo: batalha entre classes e objetos ===");
            Console.WriteLine();
            Console.WriteLine("Nesta tela vamos ver classes (moldes) sendo usadas para criar objetos (instâncias).");
            Console.WriteLine();

            var heroi = new Jogador(nome: "Herói", vidaInicial: 100, forcaInicial: 20);

            Console.WriteLine("Estado inicial do jogador:");
            Console.WriteLine($"Nome: {heroi.Nome}");
            Console.WriteLine($"Vida: {heroi.Vida}");
            Console.WriteLine($"Força: {heroi.Forca}");
            Console.WriteLine();

            var slime = new Inimigo(nome: "Slime", vidaInicial: 30, forcaInicial: 5, pontosDeRecompensa: 10);
            var goblin = new Inimigo(nome: "Goblin", vidaInicial: 40, forcaInicial: 8, pontosDeRecompensa: 20);

            Console.WriteLine("Estado inicial dos inimigos:");
            Console.WriteLine($"Inimigo 1: {slime.Nome} | Vida: {slime.Vida} | Força: {slime.Forca} | Recompensa: {slime.PontosDeRecompensa}");
            Console.WriteLine($"Inimigo 2: {goblin.Nome} | Vida: {goblin.Vida} | Força: {goblin.Forca} | Recompensa: {goblin.PontosDeRecompensa}");
            Console.WriteLine();

            Console.WriteLine("Pressione ENTER para iniciar a primeira batalha (Herói vs Slime)...");
            Console.ReadLine();

            Batalhar(heroi, slime);

            if (!heroi.EstaVivo)
            {
                Console.WriteLine("O jogador foi derrotado pelo Slime. Fim de jogo.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para iniciar a segunda batalha (Herói vs Goblin)...");
            Console.ReadLine();

            Batalhar(heroi, goblin);

            Console.WriteLine();
            Console.WriteLine("Estado final do jogador após as batalhas:");
            Console.WriteLine($"Nome: {heroi.Nome}");
            Console.WriteLine($"Vida: {heroi.Vida}");
            Console.WriteLine($"Pontuação: {heroi.Pontuacao}");
            Console.WriteLine();

            Console.WriteLine("Demonstração concluída.");
            Console.WriteLine("Observe como as CLASSES definem o que os personagens podem fazer");
            Console.WriteLine("e como os OBJETOS representam personagens específicos no jogo.");
        }

        private void Batalhar(Jogador jogador, Inimigo inimigo)
        {
            Console.WriteLine();
            Console.WriteLine($"--- Início da batalha: {jogador.Nome} vs {inimigo.Nome} ---");
            Console.WriteLine();

            while (jogador.EstaVivo && inimigo.EstaVivo)
            {
                jogador.Atacar(inimigo);
                Console.WriteLine();

                if (inimigo.EstaVivo)
                {
                    inimigo.Atacar(jogador);
                    Console.WriteLine();
                }

                Console.WriteLine("Pressione ENTER para avançar para o próximo turno...");
                Console.ReadLine();
            }

            if (jogador.EstaVivo)
            {
                Console.WriteLine($"{inimigo.Nome} foi derrotado!");
                jogador.GanharPontos(inimigo.PontosDeRecompensa);
            }
            else
            {
                Console.WriteLine($"{jogador.Nome} foi derrotado.");
            }

            Console.WriteLine($"--- Fim da batalha: {jogador.Nome} vs {inimigo.Nome} ---");
        }
    }

    // ---------------------------------------------------------
    // CLASSE Program
    // ---------------------------------------------------------
    class Program
    {
        static void Main()
        {
            var jogo = new Jogo();
            jogo.Executar();
        }
    }
}