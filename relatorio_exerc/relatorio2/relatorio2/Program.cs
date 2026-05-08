
namespace relatorio2;
class Program
{ 
    static void Main(string[] args)
    {
        SystemClass system  = new SystemClass();
        //Etapa 1 — Mensagens iniciais no console
        Console.WriteLine("Demonstração de condicionais e laços");
        Console.WriteLine();
        //Etapa 2 — Identificadores case -sensitive
        system.CaseSensitiveCase();
        //Etapa 3 — Classificação por nota com if / else if / else | Testamos com esses números: 40, 70 e 85 
        system.GradeClassifier(85);
        //Etapa 4 — Comando com switch  | Testamos com esses comandos: A, B, C e D
        system.SwitchCommand('A');
        //Etapa 5 — Contagem com o laço for | Testamos com esses números: 5, 10, 15
        system.Count(5);
        //Etapa 6 — Contagem regressiva com o laço while  | Testamos com esses números: 3, 5, 10
        system.RegressiveCount(3);
        string? entrada = null;
        do
        {
            Console.WriteLine("\nAperte enter para encerrar o console.");
            entrada = Console.ReadKey().Key.ToString();
        } while (entrada != "Enter");
    }

}

